namespace Source.Infrastructure.Services
{
    public interface IInputService
    {
        float Horizontal();
        float Vertical();
        bool IsAttackButton();
    }
}