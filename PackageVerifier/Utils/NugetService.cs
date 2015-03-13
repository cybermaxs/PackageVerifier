using NuGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageVerifier.Utils
{
    class NugetService : PackageVerifier.Utils.INugetService
    {

        public IPackage GetPackageInfos(string packageID)
        {
            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");

            //Get the list of all NuGet packages with ID 'EntityFramework'       
            var query = repo.GetPackages().Where(p => p.Id == packageID && p.IsLatestVersion);

            var target = query.FirstOrDefault();
            return target;
        }
    }
}
