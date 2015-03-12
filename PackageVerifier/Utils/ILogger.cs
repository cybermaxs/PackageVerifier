
namespace PackageVerifier.Utils
{
    interface ILogger
    {
        void Verbose(string pattern, params string[] parameters);
        void Info(string pattern, params string[] parameters);
        void Warning(string pattern, params string[] parameters);
        void Error(string pattern, params string[] parameters);
    }
}
