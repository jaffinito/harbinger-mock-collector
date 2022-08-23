namespace Harbinger.Models.Events
{
    internal class ErrorTrace
    {
        public long Timestamp { get; set; }

        public string TransactionName { get; set; }

        public string Message { get; set; }

        public string ErrorType { get; set; }

        public ErrorTraceAttributes Attributes { get; set; }

        public ErrorTrace()
        {
            Attributes = new();
        }
    }
}
