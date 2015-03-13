using CommandLine;
using System.Linq;
using CommandLine.Text;

namespace PackageVerifier
{
    public class Settings
    {
        [Option('v', "versbose", Required = false, DefaultValue = false, HelpText = "Versbose Mode")]
        public bool Verbose { get; set; }

        [Option('f', "filter", Required = false, DefaultValue = "", HelpText = "Regex filter")]
        public string Filter { get; set; }

        [Option('h', "Home", Required = true, DefaultValue = "", HelpText = "Root path")]
        public string Home { get; set; }

        [Option('p', "packageID", Required = true, DefaultValue = "", HelpText = "Package Id")]
        public string PackageID { get; set; }

        [Option('r', "reporter", Required = false, DefaultValue = "console", HelpText = "Reporter Type : console|html")]
        public string Reporters { get; set; }

        [Option('s', "source", Required = true, DefaultValue = "file", HelpText = "Source Type : file|tfs")]
        public string Source { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => {
                HelpText.DefaultParsingErrorsHandler(this, current);
            });
        }
    }
}
