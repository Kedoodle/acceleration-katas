using System;

namespace blackjack
{
    public class ConsoleUserInputGetter : IUserInputGetter
    {
        public Move GetMove()
        {
            var input = -1;
            Console.Write("[0] Hit or [1] Stay?: ");
            while (!int.TryParse(Console.ReadLine(), out input) && input != 0 && input != 1)
            {
                Console.Write("Invalid input! [0] Hit or [1] Stay?: ");
            }

            return input == 0 ? Move.Hit : Move.Stay;
        }
    }

    public interface IUserInputGetter
    {
        public Move GetMove();
    }
}