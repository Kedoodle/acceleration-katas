using System;

namespace guessing_game
{
    class Program
    {
        static void Main(string[] args)
        {
            const int min = 0;
            const int max = 100;
            var random = new Random();
            var secret = random.Next(min, max);
            var guess = -1;
            Console.WriteLine("Guess the secret number between {0} and {1}: ", min, max);
            while (guess != secret)
            {
                while (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("Invalid input! Please enter an integer: ", min, max);
                }
                if (guess != secret)
                {
                    Console.WriteLine("Your guess was too {0}. Try again: ", guess > secret ? "high" : "low");
                }
                else
                {
                    Console.WriteLine("Congratulations! Your guess of {0} was the correct answer!", guess);
                }
            }
        }
    }
}