using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Inheritance
{
    public class HighPassSummingAggregator : SummingAggregator
    {
        public HighPassSummingAggregator(IEnumerable<Measurement> measurements) : base(measurements)
        {
        }
        
        protected override IEnumerable<Measurement> FilterMeasurements(IEnumerable<Measurement> measurements)
        {
            return measurements.Where(m => m.X > 2 && m.Y > 2);
        }
    }    
}