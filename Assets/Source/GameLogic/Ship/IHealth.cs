using UniRx;

namespace Source.GameLogic.Ship
{
    public interface IHealth
    {
        FloatReactiveProperty CurrentHp { get; set; }
        float MaxHp { get; set; }
        void TakeDamage(float damage);
    }
}