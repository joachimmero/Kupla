using UnityEngine;

namespace DefaultNamespace
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private BubbleBounds bubbleBounds;

        private void Update()
        {
            foreach (var bubble in FindObjectsOfType<Bubble>())
            {
                if (bubble.Initialized)
                {
                    continue;
                }

                bubble.Initialize(new RandomCharacter(), bubbleBounds);
            }
        }
    }
}