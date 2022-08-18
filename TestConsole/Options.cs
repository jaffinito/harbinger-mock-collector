using CommandLine;

namespace TestConsole
{
    public class Options
    {
        [Option('p', "port", Required = false, HelpText = "TCP port app should listen on")]
        public string Port { get; set; }
    }
}
