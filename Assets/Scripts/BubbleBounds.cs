using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BubbleBounds : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public bool InsideBounds(Bubble bubble)
        {
            Bounds bounds = Bounds();

            return bubble.transform.position.x >= bounds.min.x + (bubble.Size.x / 2) &&
                   bubble.transform.position.x <= bounds.max.x - (bubble.Size.x / 2) &&
                   bubble.transform.position.y >= bounds.min.y + (bubble.Size.y / 2) &&
                   bubble.transform.position.y <= bounds.max.y - (bubble.Size.y / 2);
        }

        private Bounds Bounds()
        {
            return spriteRenderer.bounds;
        }
    }
}