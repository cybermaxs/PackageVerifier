using System.Threading.Tasks;

namespace PackageVerifier.Core.Reporters
{
    interface IReporter
    {
        Task GenerateAsync();
    }
}
