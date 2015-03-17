using System.Collections.Generic;

namespace PackageVerifier.Core
{
    interface IAnalytics
    {
        void Hit(string path, List<Models.Package> packages);
        HashSet<string> GetAllPackagesIds();
        HashSet<string> GetAllVersions(string packageId);
        HashSet<string> GetAllPaths();
        Dictionary<string, List<string>> GetStatsFor(string packageId);
    }
}
