using CommandLine;
using PackageVerifier.Core;
using System;
using System.Diagnostics;
using System.Linq;

namespace PackageVerifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new Settings();
            if (Parser.Default.ParseArguments(args, settings) && PostValidate(settings))
            {
                var container = Ioc.Initialize();
                container.Inject(settings);
                var processor = container.GetInstance<Processor>();

                processor.Run().Wait();
            }

            if (Debugger.IsAttached)
                Console.ReadKey();

        }

        static bool PostValidate(Settings settings)
        {
            if (!new string[] { "file", "tfs", "git" }.Contains(settings.Source))
            {
                Console.Write("Source '{0}' is not supported", settings.Source);
                return false;
            }

            if (!new string[] { "console", "html" }.Contains(settings.Reporter))
            {
                Console.Write("Reporter '{0}' is not supported", settings.Reporter);
                return false;
            }
            return true;
        }

    }
}
