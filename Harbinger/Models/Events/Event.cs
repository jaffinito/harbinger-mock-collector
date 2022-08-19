namespace Harbinger.Models.Events
{
    internal class Event
    {
        public Dictionary<string, object> InstrinsicAttributes { get; set; }

        public Dictionary<string, object> UserAttributes { get; set; }

        public Dictionary<string, object> AgentAttributes { get; set; }

        public Event()
        {
            InstrinsicAttributes = new();
            UserAttributes = new();
            AgentAttributes = new();
        }
    }
}
