using Octokit;
using PackageVerifier.Utils;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PackageVerifier.Core.Scanners
{
    class GitScanner : BaseScanner, IScanner
    {
        public GitScanner(ILogger logger, IAnalytics analytics, Settings settings)
            : base(logger, analytics, settings)
        {

        }

        public async Task ScanAsync()
        {
            // TODO
            var github = new GitHubClient(new ProductHeaderValue("PackageVerifier"));
            if (!string.IsNullOrEmpty(settings.UserName) && !string.IsNullOrEmpty(settings.Password))
                github.Credentials = new Credentials(settings.UserName, settings.Password); 
            
            var codeSearch = new SearchCodeRequest("packages.config")
	        {  
		        Repo = this.settings.Home, 
		        In = new[] {CodeInQualifier.Path}
	        };

            var codeResult = await github.Search.SearchCode(codeSearch).ConfigureAwait(false);

            foreach(var item in codeResult.Items)
            {
                var blob = await github.GitDatabase.Blob.Get(item.Repository.Owner.Login, item.Repository.Name,item.Sha).ConfigureAwait(false);
                MemoryStream stream=new MemoryStream(Convert.FromBase64String(blob.Content));
                var packages = await this.ParseConfig(stream).ConfigureAwait(false);
                this.analytics.Hit(item.Path, packages);
            }
         
        }
    }
}
