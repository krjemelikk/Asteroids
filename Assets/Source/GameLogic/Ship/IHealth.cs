using UniRx;

namespace Source.GameLogic.Ship
{
    public interface IHealth
    {
        float MaxHp { get; set; }
        FloatReactiveProperty CurrentHp { get; set; }
        void TakeDamage(float damage);
    }
}