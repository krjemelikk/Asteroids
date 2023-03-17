using UniRx;
using UnityEngine;

namespace Source.GameLogic.Ship
{
    public class ShipHealth : MonoBehaviour, IHealth
    {
        public FloatReactiveProperty CurrentHp { get; set; } = new();
        public float MaxHp { get; set; }

        public void TakeDamage(float damage)
        {
            CurrentHp.Value -= damage;

            if (CurrentHp.Value <= 0)
                Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}