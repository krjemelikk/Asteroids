using Source.GameLogic.Ship;
using UniRx;
using UnityEngine;

public class ActorUI : MonoBehaviour
{
    [SerializeField] private HpBar _hpBar;
    private IHealth _health;

    private CompositeDisposable _disposable = new();

    public void Init(IHealth health)
    {
        _health = health;
        _health.CurrentHp.Subscribe(value => OnHealthChanged(value)).AddTo(_disposable);
    }

    private void OnDestroy() =>
        _disposable.Dispose();

    private void OnHealthChanged(float currentHp) =>
        _hpBar.SetValue(_health.MaxHp, currentHp);
}