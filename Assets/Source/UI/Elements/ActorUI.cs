using Source.GameLogic.Ship;
using UnityEngine;

public class ActorUI : MonoBehaviour
{
    [SerializeField] private HpBar _hpBar;
    private IHealth _health;

    public void Init(IHealth health)
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