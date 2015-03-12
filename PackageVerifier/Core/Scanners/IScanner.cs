using PackageVerifier.Models;
using System.Threading.Tasks;

namespace PackageVerifier.Core.Scanners
{
    interface IScanner
    {
        Task ScanAsync();
    }
}
