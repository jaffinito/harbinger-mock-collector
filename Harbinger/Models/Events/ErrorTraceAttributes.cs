namespace Harbinger.Models.Events
{
    internal class ErrorTraceAttributes
    {
        public List<string> StackTrace { get; set; }

        public Dictionary<string, object> InstrinsicAttributes { get; set; }

        public Dictionary<string, object> UserAttributes { get; set; }

        public Dictionary<string, object> AgentAttributes { get; set; }

        public ErrorTraceAttributes()
        {
            StackTrace = new();
            InstrinsicAttributes = new();
            UserAttributes = new();
            AgentAttributes = new();
        }
    }
}
