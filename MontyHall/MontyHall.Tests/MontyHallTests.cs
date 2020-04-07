using System.Linq;
using Moq;
using Xunit;

namespace MontyHall.Tests
{
    public class MontyHallTests
    {
        [Fact]
        public void DoorHasPrizeNotGoat()
        {
            var door = new PrizeDoor();
            
            Assert.True(door.HasPrize());
            Assert.False(door.HasGoat());
        }
        
        [Fact]
        public void DoorHasGoatNotPrize()
        {
            var door = new GoatDoor();
            
            Assert.True(door.HasGoat());
            Assert.False(door.HasPrize());
        }

        [Fact]
        public void GameHasOnePrizeTwoGoats()
        {
            const int expectedPrizeDoors = 1;
            const int expectedGoatDoors = 2;
            
            var game = new Game(DoorIndex.First);
            var actualPrizeDoors = game.Doors.Count(door => door.HasPrize());
            var actualGoatDoors = game.Doors.Count(door => door.HasGoat());
                
            Assert.Equal(expectedPrizeDoors, actualPrizeDoors);
            Assert.Equal(expectedGoatDoors, actualGoatDoors);
        }

        [Theory]
        [InlineData(DoorIndex.First)]
        [InlineData(DoorIndex.Second)]
        [InlineData(DoorIndex.Third)]
        public void GameHasPrizeInDoor(DoorIndex doorIndex)
        {
            var game = new Game(doorIndex);
            
            Assert.True(game.GetDoor(doorIndex).HasPrize());
        }

        [Theory]
        [InlineData(DoorIndex.First, DoorIndex.First, DoorIndex.Second, ContestantDecision.Stick)]
        [InlineData(DoorIndex.First, DoorIndex.Second, DoorIndex.Third, ContestantDecision.Switch)]
        public void GameSimulatorContestantWins(DoorIndex prizeDoorIndex, DoorIndex contestantChoiceDoorIndex, DoorIndex goatRevealDoorIndex, ContestantDecision contestantDecision)
        {
            const int expectedGamesSimulated = 1;
            const int expectedContestantWins = 1;
            const int expectedContestantLosses = 0;
            
            var randomGeneratorMock = Mock.Of<IRandomGenerator>(d =>
                d.NextPrizeDoorIndex() == prizeDoorIndex &&
                d.NextContestantChoiceDoorIndex() == contestantChoiceDoorIndex &&
                d.NextGoatRevealDoorIndex() == goatRevealDoorIndex &&
                d.NextContestantDecision() == contestantDecision);
            var gameSimulator = new GameSimulator(randomGeneratorMock);
            gameSimulator.Simulate();
            var actualGamesSimulated = gameSimulator.GamesSimulated;
            var actualContestantWins = gameSimulator.ContestantWins;
            var actualContestantLosses = gameSimulator.ContestantLosses;
            
            Assert.Equal(expectedGamesSimulated, actualGamesSimulated);
            Assert.Equal(expectedContestantWins, actualContestantWins);
            Assert.Equal(expectedContestantLosses, actualContestantLosses);
        }
        
        
        [Theory]
        [InlineData(DoorIndex.First, DoorIndex.First, DoorIndex.Second, ContestantDecision.Switch)]
        [InlineData(DoorIndex.First, DoorIndex.Second, DoorIndex.Third, ContestantDecision.Stick)]
        public void GameSimulatorContestantLoses(DoorIndex prizeDoorIndex, DoorIndex contestantChoiceDoorIndex, DoorIndex goatRevealDoorIndex, ContestantDecision contestantDecision)
        {
            const int expectedGamesSimulated = 1;
            const int expectedContestantWins = 0;
            const int expectedContestantLosses = 1;
            
            var randomGeneratorMock = Mock.Of<IRandomGenerator>(d =>
                d.NextPrizeDoorIndex() == prizeDoorIndex &&
                d.NextContestantChoiceDoorIndex() == contestantChoiceDoorIndex &&
                d.NextGoatRevealDoorIndex() == goatRevealDoorIndex &&
                d.NextContestantDecision() == contestantDecision);
            var gameSimulator = new GameSimulator(randomGeneratorMock);
            gameSimulator.Simulate();
            var actualGamesSimulated = gameSimulator.GamesSimulated;
            var actualContestantWins = gameSimulator.ContestantWins;
            var actualContestantLosses = gameSimulator.ContestantLosses;
            
            Assert.Equal(expectedGamesSimulated, actualGamesSimulated);
            Assert.Equal(expectedContestantWins, actualContestantWins);
            Assert.Equal(expectedContestantLosses, actualContestantLosses);
        }
    }
}