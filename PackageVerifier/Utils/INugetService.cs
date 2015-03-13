using NuGet;
using System;
namespace PackageVerifier.Utils
{
    interface INugetService
    {
        IPackage GetPackageInfos(string packageID);
    }
}
