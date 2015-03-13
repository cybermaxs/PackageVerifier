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
            var files = Directory.EnumerateFiles(this.settings.Home, "packages.config", SearchOption.AllDirectories);
            foreach(var file in files)
            {
                if (!this.IsAllowed(file))
                    continue;
                var packages = await this.ParseConfig(File.Open(file, FileMode.Open, FileAccess.Read)).ConfigureAwait(false);
                this.analytics.Hit(file, packages);
            }
        }
    }
}
