using System;

namespace PackageVerifier.Utils
{
    class ConsoleLogger : ILogger
    {
        public void Verbose(string pattern, params string[] parameters)
        {
            Console.WriteLine("VERBOSE :" + string.Format(pattern, parameters));
        }

        public void Info(string pattern, params string[] parameters)
        {
            Console.WriteLine("INFO :" + string.Format(pattern, parameters));
        }

        public void Warning(string pattern, params string[] parameters)
        {
            Console.WriteLine("WARNING :" + string.Format(pattern, parameters));
        }

        public void Error(string pattern, params string[] parameters)
        {
            Console.WriteLine("ERROR :" + string.Format(pattern, parameters));
        }
    }
}
