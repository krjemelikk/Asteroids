using Source.GameLogic.Ship;

namespace Source.Infrastructure.Services
{
    public interface IGameplayModeService
    {
        void InitGameplaySession(GameSessionConfig gameSessionConfig);
        bool IsSessionEnd();
        void CleanUp();
    }
}