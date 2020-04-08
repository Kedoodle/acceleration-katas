namespace MontyHall
{
    public class GameSimulator
    {
        private readonly IRandomGenerator _randomGenerator;
        
        public GameSimulator(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }
        
        public int GamesSimulated { get; private set; }
        public int ContestantWins { get; private set; }
        public int ContestantLosses { get; private set; }

        public void Simulate(ContestantDecision contestantDecision, int gamesToSimulate = 1)
        {
            for (var i = 0; i < gamesToSimulate; i++)
            {
                var game = new Game(_randomGenerator)
                {
                    ContestantChoiceDoorIndex = _randomGenerator.NextContestantChoiceDoorIndex(),
                    ContestantDecision = contestantDecision
                };
                
                game.RevealGoatDoor();
            
                GamesSimulated++;
                if (game.DidContestantWin())
                {
                    ContestantWins++;
                }
                else
                {
                    ContestantLosses++;
                }
            }
        }

        public decimal GetContestantWinPercentage()
        {
            return (decimal) ContestantWins / GamesSimulated;
        }
    }
}