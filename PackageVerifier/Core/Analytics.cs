using PackageVerifier.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PackageVerifier.Core
{
    class Analytics : IAnalytics
    {
        private Dictionary<string, List<Package>> Stats = new Dictionary<string, List<Package>>();

        public void Hit(string path, List<Package> packages)
        {
            Stats[path] = packages;
        }

        public List<string> GetAllPackagesIds()
        {
            return this.Stats.Values.SelectMany(s => s).Select(p => p.Id).Distinct().ToList();
        }

        public List<string> GetAllVersions(string packageId)
        {
            return this.Stats.Values.SelectMany(s => s).Where(p => p.Id == packageId).Select(p => p.Version).Distinct().ToList();
        }

        public List<string> GetAllPaths()
        {
            return this.Stats.Keys.ToList();
        }

        public Dictionary<string, List<string>> GetStatsFor(string packageId)
        {

            var vs = GetAllVersions(packageId);

            var s = new Dictionary<string, List<string>>(vs.Count);
            foreach(var v in vs)
            {
                s.Add(v, new List<string>());
                s[v].AddRange(this.Stats.Where(kvp=> kvp.Value.Exists(p=>p.Id==packageId && p.Version==v)).Select(kvp=>kvp.Key));
            }

            return s;
        }
    }
}
