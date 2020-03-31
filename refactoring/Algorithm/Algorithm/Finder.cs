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
            var allPossiblePairsOfPeople = new List<PairOfPeople>();

            for(var i = 0; i < _people.Count - 1; i++)
            {
                for(var j = i + 1; j < _people.Count; j++)
                {
                    var r = new PairOfPeople();
                    if(_people[i].BirthDate < _people[j].BirthDate)
                    {
                        r.OlderPerson = _people[i];
                        r.YoungerPerson = _people[j];
                    }
                    else
                    {
                        r.OlderPerson = _people[j];
                        r.YoungerPerson = _people[i];
                    }
                    r.AgeDifference = r.YoungerPerson.BirthDate - r.OlderPerson.BirthDate;
                    allPossiblePairsOfPeople.Add(r);
                }
            }

            if(allPossiblePairsOfPeople.Count < 1)
            {
                return new PairOfPeople();
            }

            var answer = allPossiblePairsOfPeople[0];
            foreach(var result in allPossiblePairsOfPeople)
            {
                switch(ageDifferenceType)
                {
                    case AgeDifferenceType.Closest:
                        if(result.AgeDifference < answer.AgeDifference)
                        {
                            answer = result;
                        }
                        break;

                    case AgeDifferenceType.Furthest:
                        if(result.AgeDifference > answer.AgeDifference)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}