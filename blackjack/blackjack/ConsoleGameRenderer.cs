namespace blackjack
{
    class ConsoleGameRenderer : IGameRenderer
    {
        public void DisplayGame(GameState state)
        {
            throw new System.NotImplementedException();
        }
    }
    
    public interface IGameRenderer
    {
        public void DisplayGame(GameState state);
    }
}