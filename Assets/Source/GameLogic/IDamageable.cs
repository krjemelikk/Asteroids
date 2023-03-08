using System;

namespace Source.GameLogic
{
    public interface IDamageable
    {
        float MaxHp { get; set; }
        float CurrentHp { get; set; }
        void TakeDamage(float damage);
        event Action HealthChanged;
    }
}