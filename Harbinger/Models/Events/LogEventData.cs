using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Harbinger.Models.Events
{
    public class LogEventData : IMergeableData
    {
        // entity name
        public string AgentRunId { get; set; }

        public LogEventCommon Common { get; set; }

        public List<LogEvent> LogEvents { get; set; }

        public LogEventData(string payload)
        {
            LogEvents = new();

            var logEventData = JsonConvert.DeserializeObject<JArray>(payload).FirstOrDefault();

            var entityGuid = logEventData["common"]["attributes"]["entity.name"].ToObject<string>();
            var entityName = logEventData["common"]["attributes"]["entity.guid"].ToObject<string>();
            var hostname = logEventData["common"]["attributes"]["hostname"].ToObject<string>();

            AgentRunId = entityName;

            var logEventCommon = new LogEventCommon
            {
                Attributes = new LogEventCommonAttributes
                {
                    EntityGuid = entityGuid,
                    EntityName = entityName,
                    Hostname = hostname
                }
            };

            var logEventsArray = logEventData["logs"].Children();
            foreach (var item in logEventsArray)
            {
                LogEvents.Add(new LogEvent
                { 
                    Timestamp = item["timestamp"].ToObject<long>(),
                    Message = item["message"]?.ToObject<string>() ?? "",
                    Level = item["level"]?.ToObject<string>() ?? "",
                    SpanId = item["span.id"]?.ToObject<string>() ?? "",
                    TraceId = item["trace.id"]?.ToObject<string>() ?? "",
                });
            }
        }

        public void Merge(IMergeableData dataCollection)
        {
            var logEventData = dataCollection as LogEventData;
            LogEvents.AddRange(logEventData.LogEvents);
        }
    }
}
