using System.Linq;
using Moq;
using Xunit;

namespace MontyHall.Tests
{
    public class MontyHallTests
    {
        [Theory]
        [InlineData(DoorIndex.First)]
        [InlineData(DoorIndex.Second)]
        [InlineData(DoorIndex.Third)]
        public void GameHasPrizeInDoor(DoorIndex doorIndex)
        {
            var randomGeneratorMock = Mock.Of<IRandomGenerator>(r => r.NextPrizeDoorIndex() == doorIndex);
            var game = new Game(randomGeneratorMock);

            Assert.True(game.GetDoor(doorIndex).HasPrize());
        }

        [Theory]
        [InlineData(DoorIndex.First, DoorIndex.First, ContestantDecision.Stick)]
        [InlineData(DoorIndex.First, DoorIndex.Second, ContestantDecision.Switch)]
        public void GameSimulatorContestantWins(DoorIndex prizeDoorIndex, DoorIndex contestantChoiceDoorIndex,
            ContestantDecision contestantDecision)
        {
            const int expectedGamesSimulated = 1;
            const int expectedContestantWins = 1;
            const int expectedContestantLosses = 0;

            var randomGeneratorMock = Mock.Of<IRandomGenerator>(d =>
                d.NextPrizeDoorIndex() == prizeDoorIndex &&
                d.NextContestantChoiceDoorIndex() == contestantChoiceDoorIndex);
            var gameSimulator = new GameSimulator(randomGeneratorMock);
            gameSimulator.Simulate(contestantDecision);

            Assert.Equal(expectedGamesSimulated, gameSimulator.GamesSimulated);
            Assert.Equal(expectedContestantWins, gameSimulator.ContestantWins);
            Assert.Equal(expectedContestantLosses, gameSimulator.ContestantLosses);
        }


        [Theory]
        [InlineData(DoorIndex.First, DoorIndex.First, ContestantDecision.Switch)]
        [InlineData(DoorIndex.First, DoorIndex.Second, ContestantDecision.Stick)]
        public void GameSimulatorContestantLoses(DoorIndex prizeDoorIndex, DoorIndex contestantChoiceDoorIndex,
            ContestantDecision contestantDecision)
        {
            const int expectedGamesSimulated = 1;
            const int expectedContestantWins = 0;
            const int expectedContestantLosses = 1;

            var randomGeneratorMock = Mock.Of<IRandomGenerator>(d =>
                d.NextPrizeDoorIndex() == prizeDoorIndex &&
                d.NextContestantChoiceDoorIndex() == contestantChoiceDoorIndex);
            var gameSimulator = new GameSimulator(randomGeneratorMock);
            gameSimulator.Simulate(contestantDecision);

            Assert.Equal(expectedGamesSimulated, gameSimulator.GamesSimulated);
            Assert.Equal(expectedContestantWins, gameSimulator.ContestantWins);
            Assert.Equal(expectedContestantLosses, gameSimulator.ContestantLosses);
        }

        [Fact]
        public void DoorHasGoatNotPrize()
        {
            var door = new GoatDoor();

            Assert.True(door.HasGoat());
            Assert.False(door.HasPrize());
        }

        [Fact]
        public void DoorHasPrizeNotGoat()
        {
            var door = new PrizeDoor();

            Assert.True(door.HasPrize());
            Assert.False(door.HasGoat());
        }

        [Fact]
        public void GameHasOnePrizeTwoGoats()
        {
            const int expectedPrizeDoors = 1;
            const int expectedGoatDoors = 2;

            var randomGeneratorMock = Mock.Of<IRandomGenerator>(r => r.NextPrizeDoorIndex() == DoorIndex.First);
            var game = new Game(randomGeneratorMock);
            var actualPrizeDoors = game.Doors.Count(door => door.HasPrize());
            var actualGoatDoors = game.Doors.Count(door => door.HasGoat());

            Assert.Equal(expectedPrizeDoors, actualPrizeDoors);
            Assert.Equal(expectedGoatDoors, actualGoatDoors);
        }
    }
}