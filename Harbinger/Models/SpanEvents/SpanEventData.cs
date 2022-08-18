using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Harbinger.Models.SpanEvents
{
    internal class SpanEventData
    {
        public string AgentRunId { get; set; }

        public EventHarvestData EventHarvestData { get; set; }

        public List<SpanEvent> SpanEvents { get; set; }

        public SpanEventData(string payload)
        {
            SpanEvents = new();

            var spanEventData = JsonConvert.DeserializeObject<JArray>(payload);

            AgentRunId = spanEventData[0].ToString();

            EventHarvestData = spanEventData[1].ToObject<EventHarvestData>();

            var spanEvents = spanEventData[2];
            foreach (JArray spanEventArray in spanEvents)
            {
                var spanEvent = new SpanEvent();
                foreach (var item in (JObject)spanEventArray[0]) //InstrinsicAttributes
                {
                    spanEvent.InstrinsicAttributes.Add(item.Key, item.Value.ToObject(typeof(object)));
                }

                foreach (var item in (JObject)spanEventArray[1]) //UserAttributes
                {
                    spanEvent.UserAttributes.Add(item.Key, item.Value.ToObject(typeof(object)));
                }

                foreach (var item in (JObject)spanEventArray[2]) //AgentAttributes
                {
                    spanEvent.AgentAttributes.Add(item.Key, item.Value.ToObject(typeof(object)));
                }

                SpanEvents.Add(spanEvent);
            }
        }
    }
}
