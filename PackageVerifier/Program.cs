using CommandLine;
using PackageVerifier.Core;
using System;
using System.Diagnostics;

namespace PackageVerifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new Settings();
            if (Parser.Default.ParseArguments(args, settings))
            {
                if (Debugger.IsAttached)
                {
                    settings.Package = "Betclic.Monitoring";
                    settings.Source = "tfs";
                    settings.Home = @"http://fr-par-tfs:8080/tfs";
                }

                var container = Ioc.Initialize();
                container.Inject(settings);
                var processor = container.GetInstance<Processor>();

                processor.Run().Wait();
            }

            if (Debugger.IsAttached)
                Console.ReadKey();

        }
    }
}
