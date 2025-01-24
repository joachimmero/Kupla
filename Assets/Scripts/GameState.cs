using System;

namespace DefaultNamespace
{
    public class GameState : IGameState
    {
        public GameStateValue Value => _lives.Count() == 0
            ? GameStateValue.Ended
            : _startReceived()
                ? GameStateValue.Started
                : GameStateValue.NotStarted;

        private readonly Func<bool> _startReceived;
        private readonly ILives _lives;

        public GameState(Func<bool> startReceived, ILives lives)
        {
            _startReceived = startReceived;
            _lives = lives;
        }
    }
}