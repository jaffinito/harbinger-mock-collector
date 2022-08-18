namespace Harbinger.Data.SpanEvents
{
    public class SpanEvent
    {
        public Dictionary<string, object> InstrinsicAttributes { get; set; }

        public Dictionary<string, object> UserAttributes { get; set; }

        public Dictionary<string, object> AgentAttributes { get; set; }

        public SpanEvent()
        {
            InstrinsicAttributes = new();
            UserAttributes = new();
            AgentAttributes = new();
        }
    }
}
