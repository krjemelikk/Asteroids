using System;

namespace Source.GameLogic.Ship
{
    public interface IHealth
    {
        float MaxHp { get; set; }
        float CurrentHp { get; set; }
        void TakeDamage(float damage);
        event Action HealthChanged;
    }
}