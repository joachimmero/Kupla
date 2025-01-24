namespace DefaultNamespace
{
    public class GameState : IGameState
    {
        public bool Started { get; private set; }

        public void StartGame()
        {
            Started = true;
        }
    }
}