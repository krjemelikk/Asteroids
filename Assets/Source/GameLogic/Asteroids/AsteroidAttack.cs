using Source.GameLogic.Ship;
using UnityEngine;

namespace Source.GameLogic.Asteroids
{
    public class AsteroidAttack : MonoBehaviour
    {
        public float Damage { get; set; }

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