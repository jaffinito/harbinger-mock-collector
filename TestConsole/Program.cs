// See https://aka.ms/new-console-template for more information
using CommandLine;
using Harbinger;
using TestConsole;

// Both of the following need to be set or newrelic.config changes made to use the moc collector
// NEW_RELIC_HOST
// NEW_RELIC_PORT

Console.WriteLine("Welcome to the test console!");

var port = GetPortFromArgs(args);
var uri = "https://localhost:" + port;

var mockCollector = new MockCollector();
await mockCollector.StartCollector(uri);

string GetPortFromArgs(string[] args)
{
    var defaultHttpsPort = "5001";

    var portToUse = defaultHttpsPort;

    var commandLine = string.Join(" ", args);
    //Log($"Joined args: {commandLine}");

    Parser.Default.ParseArguments<Options>(args)
        .WithParsed(o =>
        {
            portToUse = o.Port ?? defaultHttpsPort;
            //Log($"Received port: {o.Port} | Using port: {portToUse}");
        });

    return portToUse;
}