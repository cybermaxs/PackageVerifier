using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageVerifier.Core
{
    interface IAnalytics
    {
        void Hit(string path, List<Models.Package> packages);
        List<string> GetAllPackagesIds();
        List<string> GetAllVersions(string packageId);
        List<string> GetAllPaths();
        Dictionary<string, List<string>> GetStatsFor(string packageId);
    }
}
