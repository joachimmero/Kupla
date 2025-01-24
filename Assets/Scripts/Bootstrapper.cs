using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bootstrapper : MonoBehaviour
    {
        private RandomCharacter _character;

        private void Awake()
        {
            _character = new RandomCharacter();
        }

        private void Update()
        {
            foreach (var bubble in FindObjectsOfType<Bubble>())
            {
                if (bubble.Initialized)
                {
                    continue;
                }

                bubble.Initialize(_character);
            }
        }
    }
}