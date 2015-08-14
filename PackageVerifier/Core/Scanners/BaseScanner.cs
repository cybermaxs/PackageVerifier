using PackageVerifier.Core;
using PackageVerifier.Models;
using PackageVerifier.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PackageVerifier.Core.Scanners
{
    abstract class BaseScanner
    {
        protected readonly IAnalytics analytics;
        protected readonly Settings settings;
        protected readonly ILogger logger;
        public BaseScanner(ILogger logger, IAnalytics analytics, Settings settings)
        {
            this.analytics = analytics;
            this.settings = settings;
            this.logger = logger;
        }

        protected async Task<List<Package>> ParseConfig(Stream packageStream)
        {
            var res = new List<Package>();

            try
            {
                using (var reader = new StreamReader(packageStream))
                {
                    var contents = await reader.ReadToEndAsync().ConfigureAwait(false);
                    var root = XElement.Parse(contents);
                    foreach (var xpkg in root.Elements("package"))
                    {
                        Package pkg = new Package();
                        pkg.Id = xpkg.Attribute("id").Value;
                        pkg.Version = xpkg.Attribute("version").Value;
                        //pkg.TargetFramework = xpkg.Attribute("targetFramework")!=null ? xpkg.Attribute("targetFramework").Value;
                        res.Add(pkg);
                    }
                }
            }
            catch(Exception ex)
            {
                this.logger.Error(ex.Message);
            }
            
            return res;
        }

        protected bool IsAllowed(string path)
        {
            if (string.IsNullOrEmpty(settings.Filter))
                return true;

            return path.Contains(settings.Filter);
        }
    }
}
