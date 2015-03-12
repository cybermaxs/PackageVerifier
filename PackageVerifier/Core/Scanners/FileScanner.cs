using PackageVerifier.Core;
using PackageVerifier.Models;
using PackageVerifier.Utils;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace PackageVerifier.Core.Scanners
{
    class FileScanner : BaseScanner, IScanner
    {
        public FileScanner(ILogger logger, IAnalytics analytics, Settings settings)
            : base(logger, analytics, settings)
        {

        }

        public  async Task ScanAsync()
        {
            var watcher = Stopwatch.StartNew();
            string[] files = Directory.GetFiles(this.settings.Home, "packages.config", SearchOption.AllDirectories);
            watcher.Stop();
            this.logger.Info("Scan in {0} ms", watcher.ElapsedMilliseconds.ToString());
            foreach(var file in files)
            {
                var packages = await this.ParseConfig(File.Open(file, FileMode.Open, FileAccess.Read)).ConfigureAwait(false);
                this.analytics.Hit(file, packages);
            }
        }
    }
}
