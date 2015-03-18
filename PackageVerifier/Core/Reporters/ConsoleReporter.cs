using PackageVerifier.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PackageVerifier.Core.Reporters
{
    class ConsoleReporter : IReporter
    {
        private readonly IAnalytics analytics;
        private readonly Settings settings;
        private readonly INugetService nugetService;

        public ConsoleReporter(IAnalytics analytics, Settings settings, INugetService nugetService)
        {
            this.analytics = analytics;
            this.settings = settings;
            this.nugetService = nugetService;
        }

        private string Indent(int count)
        {
            return string.Empty.PadLeft(count);
        }

        public Task GenerateAsync()
        {
            Console.WriteLine("Scanned {0} packages.config at {1} => {2}", this.analytics.GetAllPaths().Count, settings.Source, settings.Home);

            if (!string.IsNullOrEmpty(this.settings.PackageID))
                this.GeneratePackageStats();
            else
                this.GenerateSummary();

            return Task.FromResult<object>(null);
        }

        private Task GeneratePackageStats()
        {
            var pkg = this.nugetService.GetPackageInfos(settings.PackageID);
            if (pkg == null)
            {
                Console.WriteLine("The package '{0}' could not be found on the official nuget repository", settings.PackageID);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("**************************************");
                Console.WriteLine("{0} - Lastest Version {1}", pkg.Id, pkg.Version);
                Console.WriteLine("Summary : {0}", pkg.Summary);
                Console.WriteLine("**************************************");
                Console.WriteLine();
            }

            Console.WriteLine("Found {0} versions of '{1}'", this.analytics.GetAllVersions(settings.PackageID).Count, settings.PackageID);
            foreach (var stats in this.analytics.GetStatsFor(settings.PackageID))
            {
                Console.WriteLine();
                Console.WriteLine(Indent(1) + @" => Version {0}", stats.Key);
                foreach (var path in stats.Value)
                {
                    Console.WriteLine(Indent(2) + @"{0}", path);
                }
            }
            return Task.FromResult<object>(null);
        }

        private Task GenerateSummary()
        {
            foreach (var pkgId in this.analytics.GetAllPackagesIds())
            {
                var pkg = this.nugetService.GetPackageInfos(pkgId);
                var vs = this.analytics.GetAllVersions(pkgId).OrderBy(k => k);
                string status = string.Empty;
                if (pkg != null)
                    if (vs.Contains(pkg.Version.ToString()))
                        status = "LATEST";
                    else
                        status = string.Format("OUTDATED (Current {0})", pkg.Version);
                Console.WriteLine("{3} - Package '{0}' has {1} version(s) ({2})", pkgId, vs.Count(), string.Join(", ", vs), status);
            }

            return Task.FromResult<object>(null);
        }
    }
}
