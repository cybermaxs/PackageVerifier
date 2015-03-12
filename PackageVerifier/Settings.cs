using CommandLine;
using CommandLine.Text;

namespace PackageVerifier
{
    public class Settings
    {
        [Option('v', "versbose", Required = false, DefaultValue = false, HelpText = "Versbose Mode")]
        public bool Verbose { get; set; }

        [Option('f', "filter", Required = false, DefaultValue = "", HelpText = "Regex filter")]
        public string Filter { get; set; }

        [Option('h', "Home", Required = false, DefaultValue = "", HelpText = "Root path")]
        public string Home { get; set; }

        [Option('p', "package", Required = false, DefaultValue = "", HelpText = "Package Name")]
        public string Package { get; set; }

        [Option('r', "reporter", Required = false, DefaultValue = "Console", HelpText = "Reporter Type : console|html")]
        public string Reporters { get; set; }

        [Option('s', "source", Required = false, DefaultValue = "file", HelpText = "Source Type : file|tfs")]
        public string Source { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
