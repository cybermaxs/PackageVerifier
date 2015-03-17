using PackageVerifier.Core.Reporters;
using PackageVerifier.Core.Scanners;
using PackageVerifier.Utils;
using System;
using System.Threading.Tasks;

namespace PackageVerifier.Core
{
    class Processor
    {
        private readonly ILogger logger;
        private readonly IScanner scanner;
        private readonly IReporter reporter;

        public Processor(ILogger logger, IScanner scanner, IReporter reporter)
        {
            this.logger = logger;
            this.scanner = scanner;
            this.reporter = reporter;
        }

        public async Task Run()
        {
            try
            {
                // run scanner
                await this.scanner.ScanAsync().ConfigureAwait(false);

                // run reporter
                await this.reporter.GenerateAsync().ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR => "+ex.Message);
            }
        }
    }
}
