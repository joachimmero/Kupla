using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private BubbleBounds bubbleBounds;

        private ILives _lives;

        private int _escapedBubbleCount;

        private void Awake()
        {
            _lives = new EscapedBubblesLives(() => _escapedBubbleCount);
        }

        private void Update()
        {
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

            if (_lives.Count() == 0)
            {
                SceneManager.LoadScene(sceneBuildIndex: 0);
            }
        }
    }
}