using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Harbinger.Models.Events
{
    internal class CustomEventData : IMergeableData
    {
        public string AgentRunId { get; set; }

        public List<Event> Events { get; set; }

        public CustomEventData(string payload)
        {
            Events = new();

            var eventData = JsonConvert.DeserializeObject<JArray>(payload);

            AgentRunId = eventData[0].ToString();

            var events = eventData[1];
            foreach (JArray eventArray in events)
            {
                var eventObj = new Event();
                foreach (var item in (JObject)eventArray[0]) //InstrinsicAttributes
                {
                    TryAddAttribute(item, eventObj.InstrinsicAttributes);
                }

                foreach (var item in (JObject)eventArray[1]) //UserAttributes
                {
                    TryAddAttribute(item, eventObj.UserAttributes);
                }

                foreach (var item in (JObject)eventArray[2]) //AgentAttributes
                {
                    TryAddAttribute(item, eventObj.AgentAttributes);
                }

                Events.Add(eventObj);
            }
        }

        public void Merge(IMergeableData dataCollection)
        {
            var customEventData = dataCollection as CustomEventData;
            Events.AddRange(customEventData.Events);
        }

        private void TryAddAttribute(KeyValuePair<string, JToken> pair, Dictionary<string, object> attributes)
        {
            var key = pair.Key;
            var value = pair.Value.ToObject(typeof(object));
            if (attributes.ContainsKey(key))
            {
                // agent can add some entries twice, like  "type", so we just skip the second one.
                return;
            }

            attributes.Add(key, value); // this null is okay. Some of our properties are sent up as null.
        }
    }
}
