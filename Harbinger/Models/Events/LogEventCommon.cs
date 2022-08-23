namespace Harbinger.Models.Events
{
    public class LogEventCommon
    {
        public LogEventCommonAttributes Attributes { get; set; }

        public LogEventCommon()
        {
            Attributes = new LogEventCommonAttributes();
        }
    }
}
