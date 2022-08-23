namespace Harbinger.Models.Events
{
    internal class TraceDetailSegment
    {
        public double RelativeStartTime { get; set; }

        public double RelativeStopTime { get; set; }

        public string Name { get; set; }

        public Dictionary<string, object> Attributes { get; set; }

        public List<TraceDetailSegment> Segments { get; set; }

        public string ClassName { get; set; }

        public string MethodName { get; set; }

        public TraceDetailSegment()
        {
            RelativeStartTime = -1;
            RelativeStopTime = -1;
            Attributes = new();
            Segments = new();
        }
    }
}
