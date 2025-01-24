using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameStateView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public bool Initialized { get; private set; }

        private IGameState _gameState;

        public void Initialize(IGameState gameState)
        {
            _gameState = gameState;

            Initialized = true;
        }

        private void Update()
        {
            if (!Initialized)
            {
                return;
            }

            text.text = _gameState.Started
                ? ""
                : "Press any key to start";
        }
    }
}