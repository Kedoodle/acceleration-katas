using System;
using System.Linq;

namespace MontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            const int gamesToSimulate = 1000;
            var randomGenerator = new RandomGenerator();
            
            foreach (var contestantDecision in Enum.GetValues(typeof(ContestantDecision)).Cast<ContestantDecision>())
            {
                Console.WriteLine($"Simulating {gamesToSimulate} games with the contestant always deciding to: {contestantDecision}");
                
                var gameSimulator = new GameSimulator(randomGenerator);
                gameSimulator.Simulate(contestantDecision, gamesToSimulate);
                
                Console.WriteLine($"The contestant won {gameSimulator.ContestantWins} out of {gameSimulator.GamesSimulated} games ({gameSimulator.GetContestantWinPercentage():P})");
            }
        }
    }
}