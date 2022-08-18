namespace Harbinger.Models.Metrics
{
    internal class Timeslice
    {
        public int Count { get; internal set; }
        public double Totaltime { get; internal set; }
        public double ExclusiveTime { get; internal set; }
        public double MinTime { get; internal set; }
        public double MaxTime { get; internal set; }
        public double SumOfSquares { get; internal set; }

        public Timeslice(int count, double totalTime, double exclusiveTime, double mintime, double maxTime, double sumOfSquares)
        {
            Count = count;
            Totaltime = totalTime;
            ExclusiveTime = exclusiveTime;
            MinTime = mintime;
            MaxTime = maxTime;
            SumOfSquares = sumOfSquares;
        }

        public void UpdateTimeSlice(int count, double totalTime, double exclusiveTime, double mintime, double maxTime, double sumOfSquares)
        {
            Count += count;
            Totaltime += totalTime;
            ExclusiveTime += exclusiveTime;
            MinTime += mintime;
            MaxTime += maxTime;
            SumOfSquares += sumOfSquares;
        }
    }
}
