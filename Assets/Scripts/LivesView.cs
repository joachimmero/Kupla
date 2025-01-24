using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class LivesView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public bool Initialized { get; private set; }

        private ILives _lives;

        private int _livesCache = int.MaxValue;

        public void Initialize(ILives lives)
        {
            _lives = lives;

            Initialized = true;
        }

        private void Update()
        {
            if (!Initialized)
            {
                return;
            }

            if (_lives.Count() == _livesCache)
            {
                return;
            }

            text.text = $"Lives: {_lives.Count()}";
            _livesCache = _lives.Count();
        }
    }
}