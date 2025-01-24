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

            return bubble.transform.position.x >= bounds.min.x &&
                   bubble.transform.position.x <= bounds.max.y &&
                   bubble.transform.position.y >= bounds.min.y &&
                   bubble.transform.position.y <= bounds.max.y;
        }

        private Bounds Bounds()
        {
            return spriteRenderer.bounds;
        }
    }
}