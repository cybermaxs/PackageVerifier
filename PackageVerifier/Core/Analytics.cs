using PackageVerifier.Models;
using System.Collections.Generic;
using System.Linq;

namespace PackageVerifier.Core
{
    class Analytics : IAnalytics
    {
        private Dictionary<string, List<Package>> Stats = new Dictionary<string, List<Package>>();

        private HashSet<string> PackageIds = new HashSet<string>();
        private HashSet<string> Paths = new HashSet<string>();
        private Dictionary<string, HashSet<string>> PackagesVersions = new Dictionary<string, HashSet<string>>();

        public void Hit(string path, List<Package> packages)
        {
            if (packages != null)
                foreach (var p in packages)
                {
                    //ids index
                    PackageIds.Add(p.Id);

                    //versions
                    HashSet<string> currentVersions = null;
                    if (PackagesVersions.TryGetValue(p.Id, out currentVersions))
                    {
                        currentVersions.Add(p.Version);
                    }
                    else
                    {
                        currentVersions = new HashSet<string>();
                        currentVersions.Add(p.Version);
                        PackagesVersions.Add(p.Id, currentVersions);
                    }
                }

            //paths index
            Paths.Add(path);



            Stats[path] = packages;
        }

        public HashSet<string> GetAllPackagesIds()
        {
            return this.PackageIds;
        }

        public HashSet<string> GetAllVersions(string packageId)
        {
            HashSet<string> versions=new HashSet<string>();
            this.PackagesVersions.TryGetValue(packageId, out versions);
            return versions??new HashSet<string>();
        }

        public HashSet<string> GetAllPaths()
        {
            return this.Paths;
        }

        public Dictionary<string, List<string>> GetStatsFor(string packageId)
        {

            var vs = GetAllVersions(packageId).OrderByDescending(k=>k);

            var s = new Dictionary<string, List<string>>(vs.Count());
            foreach (var v in vs)
            {
                s.Add(v, new List<string>());
                s[v].AddRange(this.Stats.Where(kvp => kvp.Value.Exists(p => p.Id == packageId && p.Version == v)).Select(kvp => kvp.Key));
            }

            return s;
        }
    }
}
