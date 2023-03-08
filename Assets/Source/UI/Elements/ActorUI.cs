using Source.GameLogic;
using UnityEngine;
using Zenject;

public class ActorUI : MonoBehaviour
{
    [SerializeField] private HpBar _hpBar;
    private IDamageable _health;

    [Inject]
    private void Construct(IDamageable health)
    {
        _health = health;
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        _hpBar.SetValue(_health.MaxHp, _health.CurrentHp);
    }
}