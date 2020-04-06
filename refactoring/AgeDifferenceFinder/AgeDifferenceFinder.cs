using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class AgeDifferenceFinder
    {
        private readonly List<Person> _people;

        public AgeDifferenceFinder(List<Person> people)
        {
            _people = people;
        }

        public PairOfPeople Find(AgeDifferenceType ageDifferenceType)
        {
            if (!HasEnoughPeople()) return new PairOfPeople();
            
            var candidates = GetAllPossiblePairsOfPeople();

            return ageDifferenceType == AgeDifferenceType.Closest ? GetClosestBirthdayPair(candidates) : GetFurthestBirthdayPair(candidates);
        }

        private bool HasEnoughPeople()
        {
            const int peopleRequiredToMakeAPair = 2;
            return _people.Count >= peopleRequiredToMakeAPair;
        }

        private IEnumerable<PairOfPeople> GetAllPossiblePairsOfPeople()
        {
            var allPossiblePairsOfPeople = new List<PairOfPeople>();

            for (var i = 0; i < _people.Count - 1; i++)
            {
                for (var j = i + 1; j < _people.Count; j++)
                {
                    var olderPerson = _people[i].BirthDate < _people[j].BirthDate ? _people[i] : _people[j];
                    var youngerPerson = _people[i].BirthDate < _people[j].BirthDate ? _people[j] : _people[i];
                    allPossiblePairsOfPeople.Add(new PairOfPeople {OlderPerson = olderPerson, YoungerPerson = youngerPerson});
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