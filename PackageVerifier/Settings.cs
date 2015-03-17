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

        [Option('h', "Home", Required = true, DefaultValue = "", HelpText = "Root path")]
        public string Home { get; set; }

        [Option('p', "packageID", Required = false, DefaultValue = "", HelpText = "Package Id")]
        public string PackageID { get; set; }

        [Option('r', "reporter", Required = false, DefaultValue = "console", HelpText = "Reporter Type : console|html")]
        public string Reporter { get; set; }

        [Option('s', "source", Required = true, DefaultValue = "file", HelpText = "Source Type : file|tfs|git")]
        public string Source { get; set; }

        [Option('u', "user", Required = false, DefaultValue = "", HelpText = "Git User Name")]
        public string UserName { get; set; }
        [Option('a', "password", Required = false, DefaultValue = "", HelpText = "Git Password")]
        public string Password { get; set; }

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
