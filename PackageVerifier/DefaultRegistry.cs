using PackageVerifier.Core;
using PackageVerifier.Core.Reporters;
using PackageVerifier.Core.Scanners;
using PackageVerifier.Utils;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace PackageVerifier
{
    public class DefaultRegistry : Registry
    {

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            // runner
            For<Processor>().Use<Processor>().Singleton();

            //analytics
            For<IAnalytics>().Use<Analytics>().Singleton();

            //tools
            For<ILogger>().Use<ConsoleLogger>().Singleton();
            For<INugetService>().Use<NugetService>().Singleton();

            //scanners
            For<IScanner>().Use<FileScanner>().Named("file");
            For<IScanner>().Use<TfsScanner>().Named("tfs");
            For<IScanner>().Use<GitScanner>().Named("git");

            //reporters
            For<IReporter>().Use<ConsoleReporter>().Named("console");
            For<IReporter>().Use<HtmlReporter>().Named("html");

            //factories
            For<IScanner>().Use("scannerFactory", e =>
            {
                var settings = e.GetInstance<Settings>();
                return e.GetInstance<IScanner>(settings.Source.ToLowerInvariant());
            });
            For<IReporter>().Use("reporterFactory", e =>
            {
                var settings = e.GetInstance<Settings>();
                return e.GetInstance<IReporter>(settings.Reporter.ToLowerInvariant());
            });
        }
    }
}
