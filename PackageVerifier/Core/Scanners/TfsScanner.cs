using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.VersionControl.Client;
using PackageVerifier.Utils;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PackageVerifier.Core.Scanners
{
    class TfsScanner : BaseScanner, IScanner
    {
        public TfsScanner(ILogger logger, IAnalytics analytics, Settings settings)
            : base(logger, analytics, settings)
        {

        }

        public async Task ScanAsync()
        {
            Uri tfsUri = new Uri(this.settings.Home);

            var tfsCreds = new TfsClientCredentials(new WindowsCredential(), true);

            TfsConfigurationServer configurationServer = TfsConfigurationServerFactory.GetConfigurationServer(tfsUri);

            // Get the catalog of team project collections
            ReadOnlyCollection<CatalogNode> collectionNodes = configurationServer.CatalogNode.QueryChildren(new[] { CatalogResourceTypes.ProjectCollection }, false, CatalogQueryOptions.None);

            // List the team project collections
            foreach (CatalogNode collectionNode in collectionNodes)
            {
                // Use the InstanceId property to get the team project collection
                Guid collectionId = new Guid(collectionNode.Resource.Properties["InstanceId"]);
                TfsTeamProjectCollection teamProjectCollection = configurationServer.GetTeamProjectCollection(collectionId);
                VersionControlServer version = teamProjectCollection.GetService(typeof(VersionControlServer)) as VersionControlServer;

                // Get a catalog of team projects for the collection
                ReadOnlyCollection<CatalogNode> projectNodes = collectionNode.QueryChildren(new[] { CatalogResourceTypes.TeamProject }, false, CatalogQueryOptions.None);

                // List the team projects in the collection
                foreach (CatalogNode projectNode in projectNodes)
                {
                    ItemSet items = version.GetItems(@"$\" + projectNode.Resource.DisplayName + @"\packages.config", VersionSpec.Latest, RecursionType.Full, DeletedState.NonDeleted, ItemType.File);

                    foreach (Item item in items.Items)
                    {
                        if (!this.IsAllowed(item.ServerItem))
                            continue;

                        try
                        {
                            var stream = item.DownloadFile();
                            var packages = await this.ParseConfig(stream).ConfigureAwait(false);

                            this.analytics.Hit(item.ServerItem, packages);
                        }
                        catch(Exception ex)
                        {
                            this.logger.Error("Could not downloadfile {0}=> {1}", item.ServerItem, ex.Message);
                        }
                    }
                }
            }

        }
    }
}
