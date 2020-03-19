using System;

namespace blackjack
{
    public class ConsoleUserInputGetter : IUserInputGetter
    {
        public Move GetMove()
        {
            var input = -1;
            Console.Write("[1] Hit or [0] Stay?: ");
            while (!int.TryParse(Console.ReadLine(), out input) || (input != 1 && input != 0))
            {
                Console.Write("Invalid input! [1] Hit or [0] Stay?: ");
            }

            return input == 1 ? Move.Hit : Move.Stay;
        }
    }

    public interface IUserInputGetter
    {
        public Move GetMove();
    }
}