namespace Harbinger.Models.Events
{
    public class LogEvent
    {
        public long Timestamp { get; set; }

        public string Message { get; set; }

        public string Level { get; set; }

        public string SpanId { get; set; }

        public string TraceId { get; set; }
    }
}
