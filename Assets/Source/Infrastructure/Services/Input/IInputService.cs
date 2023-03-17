namespace Source.Infrastructure.Services.Input
{
    public interface IInputService
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool IsAttackButtonDown { get; }
    }
}