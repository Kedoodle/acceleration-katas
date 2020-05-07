using System;
using System.IO;
using Moq;
using Xunit;

namespace Minesweeper.Tests.AcceptanceTests
{
    public class GameShould
    {
        [Fact]
        public void TakeConsoleInputAndWriteFieldsToConsoleOutput()
        {
            const string expectedFirstHeader = "Field #1:";
            var expectedFirstField = "*100" + Environment.NewLine +
                                            "2210" + Environment.NewLine +
                                            "1*10" + Environment.NewLine +
                                            "1110";
            
            const string expectedSecondHeader = "Field #2:";
            var expectedSecondField = "**100" + Environment.NewLine +
                                             "33200" + Environment.NewLine +
                                             "1*100";

            var mockInputStream = new Mock<TextReader>();
            mockInputStream.SetupSequence(i => i.ReadLine())
                .Returns("44")
                .Returns("*...")
                .Returns("....")
                .Returns(".*..")
                .Returns("....")
                .Returns("35")
                .Returns("**...")
                .Returns(".....")
                .Returns(".*...")
                .Returns("00");
            var mockOutputStream = new Mock<TextWriter>();

            var consoleReader = new InputReader(mockInputStream.Object);
            var consoleWriter = new OutputWriter(mockOutputStream.Object);
            var game = new Game(consoleReader, consoleWriter);
            
            game.Run();
            
            mockOutputStream.Verify(m => m.WriteLine(expectedFirstHeader), Times.Once);
            mockOutputStream.Verify(m => m.WriteLine(expectedFirstField), Times.Once);
            mockOutputStream.Verify(m => m.WriteLine(expectedSecondHeader), Times.Once);
            mockOutputStream.Verify(m => m.WriteLine(expectedSecondField), Times.Once);
        }
    }
}