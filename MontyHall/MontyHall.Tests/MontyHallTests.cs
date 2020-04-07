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
    }
}