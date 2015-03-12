using System;
using System.Linq;
using System.Threading.Tasks;

namespace PackageVerifier.Core.Reporters
{
    class ConsoleReporter : IReporter
    {
        private readonly IAnalytics analytics;
        private readonly Settings settings;

        public ConsoleReporter(IAnalytics analytics, Settings settings)
        {
            this.analytics = analytics;
            this.settings = settings;
        }

        public Task GenerateAsync()
        {
            Console.WriteLine("Found {0} packages.config in {1}:{2}", this.analytics.GetAllPaths().Count, settings.Source, settings.Home);

            if (!string.IsNullOrEmpty(settings.Package))
            {
                Console.WriteLine("Found {0} version for {1}", this.analytics.GetAllVersions(settings.Package).Count, settings.Package);
                foreach (var stats in this.analytics.GetStatsFor(settings.Package))
                {
                    Console.WriteLine("=>Version {0}", stats.Key);
                    foreach (var path in stats.Value)
                    {
                        Console.WriteLine("- {0}", path);
                    }
                }
            }
            else
            {
                foreach (var pkg in this.analytics.GetAllPackagesIds())
                {
                    Console.WriteLine("Found {0} version for {1}", this.analytics.GetAllVersions(pkg).Count, pkg);
                }
            }

            return Task.FromResult<object>(null);
        }
    }
}
