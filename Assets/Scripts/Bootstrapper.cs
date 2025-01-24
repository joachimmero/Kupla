using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private BubbleBounds bubbleBounds;

        private ILives _lives;

        private bool _startReceived;
        private int _escapedBubbleCount;
        private GameState _gameState;

        private void Awake()
        {
            _lives = new EscapedBubblesLives(() => _escapedBubbleCount);
            _gameState = new GameState(() => _startReceived, _lives);
        }

        private void Update()
        {
            if (_gameState.Value == GameStateValue.NotStarted)
            {
                if (Input.anyKeyDown)
                {
                    _startReceived = true;
                }
            }

            if (_gameState.Value == GameStateValue.Ended)
            {
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene(sceneBuildIndex: 0);
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

                bubble.Initialize(new RandomCharacter(), bubbleBounds, _gameState);
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
        }
    }
}