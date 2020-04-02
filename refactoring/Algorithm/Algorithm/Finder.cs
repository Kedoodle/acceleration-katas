using System.Collections.Generic;
using System.Linq;

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

            return ageDifferenceType == AgeDifferenceType.Closest ? GetClosestBirthdayPair(candidates) : GetFurthestBirthdayPair(candidates);
        }

        private bool NotEnoughPeople()
        {
            return _people.Count < 2;
        }

        private IEnumerable<PairOfPeople> GetAllPossiblePairsOfPeople()
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
                    allPossiblePairsOfPeople.Add(pair);
                }
            }

            return allPossiblePairsOfPeople;
        }

        private static PairOfPeople GetClosestBirthdayPair(IEnumerable<PairOfPeople> candidates)
        {
            return candidates.OrderBy(candidate => candidate.GetAgeDifference()).First();
        }

        private static PairOfPeople GetFurthestBirthdayPair(IEnumerable<PairOfPeople> candidates)
        {
            return candidates.OrderByDescending(candidate => candidate.GetAgeDifference()).First();
        }
    }
}