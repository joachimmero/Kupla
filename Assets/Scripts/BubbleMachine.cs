using UnityEngine;

namespace DefaultNamespace
{
    public class BubbleMachine : MonoBehaviour
    {
        [SerializeField] private float interval;
        [SerializeField] private int amount;
        [SerializeField] private Bubble prefab;
        [SerializeField] private Transform origin;

        private float _lastBurst;

        public void Start()
        {
            _lastBurst = Time.time;
        }

        private void Update()
        {
            if (Time.time >= _lastBurst + interval)
            {
                for (int i = 0; i < amount; i++)
                {
                    Bubble bubble = Instantiate(prefab, new Vector3(
                        Random.Range(-1.5f, 1.5f),
                        Random.Range(-1.5f, 1.5f),
                        0f), Quaternion.identity);

                    bubble.AddForce(new Vector2(
                        Random.Range(-1f, 1f),
                        Random.Range(-1f, 1f)));
                }

                _lastBurst = Time.time;
            }
        }
    }
}