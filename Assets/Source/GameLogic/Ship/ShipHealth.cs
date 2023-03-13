using System;
using UnityEngine;

namespace Source.GameLogic.Ship
{
    public class ShipHealth : MonoBehaviour, IHealth
    {
        private float _currentHp;

        public event Action HealthChanged;
        public float MaxHp { get; set; }

        public float CurrentHp
        {
            get => _currentHp;
            set
            {
                _currentHp = value;
                HealthChanged?.Invoke();
            }
        }

        public void TakeDamage(float damage)
        {
            CurrentHp -= damage;
            
            if (CurrentHp <= 0)
                Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}