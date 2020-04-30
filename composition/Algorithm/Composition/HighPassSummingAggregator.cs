using System.Collections.Generic;

namespace Algorithm.Composition
{
    public class HighPassSummingAggregator : PointsAggregator
    {
        public HighPassSummingAggregator(IEnumerable<Measurement> measurements)
            : base(measurements, new HighPassFilter(), new SummingStrategy())
        {
        }
    }
}