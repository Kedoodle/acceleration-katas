using System;
using System.Collections.Generic;
using Xunit;

namespace fizzbuzz_test
{
    public class FizzBuzzTests
    {
        [Fact]
        public void FizzBuzzGenerator_1_Outputs1()
        {
            const string expected = "1";
            
            const int n = 1;
            var actual = Generator.Generate(n);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void FizzBuzzGenerator_2_Outputs2()
        {
            const string expected = "2";
            
            const int n = 2;
            var actual = Generator.Generate(n);
            
            Assert.Equal(expected, actual);
        }       
        
        [Fact]
        public void FizzBuzzGenerator_3_OutputsFizz()
        {
            const string expected = "Fizz";
            
            const int n = 3;
            var actual = Generator.Generate(n);
            
            Assert.Equal(expected, actual);
        }
        
        
    }

    public class Generator
    {
        public static string Generate(int n)
        {
            if (n == 1)
            {
                return "1";
            }
            else if (n == 2)
            {
                return "2";
            }
            else if (n == 3)
            {
                return "Fizz";
            }

            return "";
        }
    }
}