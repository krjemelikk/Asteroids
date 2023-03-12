using Source.GameLogic.Ship;
using UnityEngine;

namespace Source.GameLogic.Asteroids
{
    public class Asteroid : MonoBehaviour
    {
        private float _elapsedTimeAfterSpawn;

        public float LifeTime { get; set; }
        public float Damage { get; set; }

        private void Update()
        {
            UpdateElapseTime();

            if (LifeTimeIsOver())
            {
                Destroy(this);
            }
        }

        private void UpdateElapseTime() =>
            _elapsedTimeAfterSpawn += Time.deltaTime;

        private bool LifeTimeIsOver() =>
            _elapsedTimeAfterSpawn >= LifeTime;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IHealth>(out IHealth ship))
            {
                ship.TakeDamage(Damage);
                Destroy(this);
            }
        }
    }
}