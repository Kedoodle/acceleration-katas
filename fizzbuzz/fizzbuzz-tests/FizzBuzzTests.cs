using fizzbuzz;
using Xunit;

namespace fizzbuzz_tests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void FizzBuzzGenerate_1_Outputs1()
        {
            const string expected = "1";
            var actual = FizzBuzzGenerator.Generate(1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FizzBuzzGenerate_2_Outputs2()
        {
            const string expected = "2";
            var actual = FizzBuzzGenerator.Generate(2);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void FizzBuzzGenerate_3_OutputsFizz()
        {
            const string expected = "Fizz";
            var actual = FizzBuzzGenerator.Generate(3);
            Assert.Equal(expected, actual);
        } 
        
        [Fact]
        public void FizzBuzzGenerate_4_Outputs4()
        {
            const string expected = "4";
            var actual = FizzBuzzGenerator.Generate(4);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void FizzBuzzGenerate_5_OutputsBuzz()
        {
            const string expected = "Buzz";
            var actual = FizzBuzzGenerator.Generate(5);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void FizzBuzzGenerate_6_OutputsFizz()
        {
            const string expected = "Fizz";
            var actual = FizzBuzzGenerator.Generate(6);
            Assert.Equal(expected, actual);
        }  
        
        [Fact]
        public void FizzBuzzGenerate_7_Outputs7()
        {
            const string expected = "7";
            var actual = FizzBuzzGenerator.Generate(7);
            Assert.Equal(expected, actual);
        }  
        
        [Fact]
        public void FizzBuzzGenerate_10_OutputsBuzz()
        {
            const string expected = "Buzz";
            var actual = FizzBuzzGenerator.Generate(10);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void FizzBuzzGenerate_15_OutputsFizzBuzz()
        {
            const string expected = "FizzBuzz";
            var actual = FizzBuzzGenerator.Generate(15);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void FizzBuzzGenerate_30_OutputsFizzBuzz()
        {
            const string expected = "FizzBuzz";
            var actual = FizzBuzzGenerator.Generate(30);
            Assert.Equal(expected, actual);
        }
        
    }
}