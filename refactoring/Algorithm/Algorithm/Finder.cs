using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> people)
        {
            _people = people;
        }

        public PairOfPeople Find(AgeDifferenceType ageDifferenceType)
        {
            if (NotEnoughPeople()) return new PairOfPeople();
            
            var candidates = GetAllPossiblePairsOfPeople();

            var result = candidates[0];
            foreach(var candidate in candidates)
            {
                switch(ageDifferenceType)
                {
                    case AgeDifferenceType.Closest:
                        if(candidate.AgeDifference < result.AgeDifference)
                        {
                            result = candidate;
                        }
                        break;

                    case AgeDifferenceType.Furthest:
                        if(candidate.AgeDifference > result.AgeDifference)
                        {
                            result = candidate;
                        }
                        break;
                }
            }

            return result;
        }

        private bool NotEnoughPeople()
        {
            return _people.Count < 2;
        }

        private List<PairOfPeople> GetAllPossiblePairsOfPeople()
        {
            var allPossiblePairsOfPeople = new List<PairOfPeople>();

            for (var i = 0; i < _people.Count - 1; i++)
            {
                for (var j = i + 1; j < _people.Count; j++)
                {
                    var pair = new PairOfPeople();
                    if (_people[i].BirthDate < _people[j].BirthDate)
                    {
                        pair.OlderPerson = _people[i];
                        pair.YoungerPerson = _people[j];
                    }
                    else
                    {
                        pair.OlderPerson = _people[j];
                        pair.YoungerPerson = _people[i];
                    }

                    pair.AgeDifference = pair.YoungerPerson.BirthDate - pair.OlderPerson.BirthDate;
                    allPossiblePairsOfPeople.Add(pair);
                }
            }

            return allPossiblePairsOfPeople;
        }
    }
}