namespace blackjack
{
    public class ConsoleUserInputGetter : IUserInputGetter
    {
        public Move GetMove()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IUserInputGetter
    {
        public Move GetMove();
    }
}