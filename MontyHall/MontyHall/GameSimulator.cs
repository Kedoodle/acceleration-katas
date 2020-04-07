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

        public void Simulate(int gamesToSimulate = 1)
        {
            for (var i = 0; i < gamesToSimulate; i++)
            {
                var prizeDoorIndex = _randomGenerator.NextPrizeDoorIndex();
                var game = new Game(prizeDoorIndex)
                {
                    ContestantChoiceDoorIndex = _randomGenerator.NextContestantChoiceDoorIndex(),
                    GoatRevealDoorIndex = _randomGenerator.NextGoatRevealDoorIndex(),
                    ContestantDecision = _randomGenerator.NextContestantDecision()
                };
            
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
    }
}