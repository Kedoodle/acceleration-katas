using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Composition
{
    public class HighPassFilter : IMeasurementFilter
    {
        public IEnumerable<Measurement> Filter(IEnumerable<Measurement> measurements)
        {
            return measurements.Where(m => m.X > 2 & m.Y > 2);
        }
    }
}