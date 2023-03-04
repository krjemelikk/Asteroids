namespace Source.Infrastructure.Services
{
    public interface IInputService
    {
        float Horizontal { get; }
        float Vertical{ get; }
        bool IsAttackButton{ get; }
    }
}