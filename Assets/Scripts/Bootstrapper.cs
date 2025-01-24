using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private BubbleBounds bubbleBounds;

        private ILives _lives;

        private int _escapedBubbleCount;
        private GameState _gameState;

        private void Awake()
        {
            _lives = new EscapedBubblesLives(() => _escapedBubbleCount);
            _gameState = new GameState();
        }

        private void Update()
        {
            if (!_gameState.Started)
            {
                if (Input.anyKeyDown)
                {
                    _gameState.StartGame();
                }
            }

            foreach (var machine in FindObjectsOfType<BubbleMachine>())
            {
                if (machine.Initialized)
                {
                    continue;
                }

                machine.Initialize(_gameState);
            }

            foreach (var bubble in FindObjectsOfType<Bubble>())
            {
                if (bubble.Initialized)
                {
                    continue;
                }

                bubble.Initialize(new RandomCharacter(), bubbleBounds);
                bubble.Escaped += () => _escapedBubbleCount++;
            }

            foreach (var livesView in FindObjectsOfType<LivesView>())
            {
                if (livesView.Initialized)
                {
                    continue;
                }

                livesView.Initialize(_lives);
            }

            foreach (var gameStateView in FindObjectsOfType<GameStateView>())
            {
                if (gameStateView.Initialized)
                {
                    continue;
                }

                gameStateView.Initialize(_gameState);
            }

            if (_lives.Count() == 0)
            {
                SceneManager.LoadScene(sceneBuildIndex: 0);
            }
        }
    }
}