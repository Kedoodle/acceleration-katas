using System;

namespace AgeDifferenceFinder
{
    public class PairOfPeople
    {
        public Person OlderPerson { get; set; }
        public Person YoungerPerson { get; set; }

        public TimeSpan GetAgeDifference()
        {
            return YoungerPerson.BirthDate - OlderPerson.BirthDate;
        }
    }
}