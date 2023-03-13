namespace Source.Infrastructure.Services
{
    public class GameplayModeService : IGameplayModeService
    {
        private GameSessionConfig _gameSessionConfig;

        public void InitGameplaySession(GameSessionConfig gameSessionConfig) =>
            _gameSessionConfig = gameSessionConfig;

        public void CleanUp() =>
            _gameSessionConfig = null;

        public bool IsSessionEnd() =>
            !IsPlayerAlive();

        private bool IsPlayerAlive()
            => _gameSessionConfig.Player.CurrentHp > 0;
    }
}