using System;

namespace DefaultNamespace
{
    public class EscapedBubblesLives : ILives
    {
        private readonly Func<int> _escapedBubbleCount;

        public EscapedBubblesLives(Func<int> escapedBubbleCount)
        {
            _escapedBubbleCount = escapedBubbleCount;
        }

        public int Count()
        {
            return Math.Max(3 - _escapedBubbleCount(), 0);
        }
    }
}