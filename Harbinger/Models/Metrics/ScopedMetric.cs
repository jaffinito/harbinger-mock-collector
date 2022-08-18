namespace Harbinger.Models.Metrics
{
    public class ScopedMetric
    {
        public string Name { get; internal set; }
        public Timeslice Timeslice { get; internal set; }

        public ScopedMetric(string name, Timeslice timeSlice)
        {
            Name = name;
            Timeslice = timeSlice;
        }

        public void UpdateTimeSlice(int count, double totalTime, double exclusiveTime, double mintime, double maxTime, double sumOfSquares)
        {
            Timeslice.UpdateTimeSlice(count, totalTime, exclusiveTime, mintime, maxTime, sumOfSquares);
        }
    }
}
