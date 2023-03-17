using Source.Infrastructure.Services;
using Zenject;

namespace Source.Infrastructure.StateMachine.States
{
    public class GameLoopState : IConfigurableState<GameSessionConfig>, ITickable
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameplayModeService _gameplayModeService;

        public GameLoopState(IGameStateMachine gameStateMachine, IGameplayModeService gameplayModeService)
        {
            _gameStateMachine = gameStateMachine;
            _gameplayModeService = gameplayModeService;
        }

        public void Enter(GameSessionConfig config) =>
            _gameplayModeService.InitGameplaySession(config);

        public void Exit() =>
            _gameplayModeService.CleanUp();

        public void Tick()
        {
            if (_gameplayModeService.IsSessionEnd())
            {
                _gameStateMachine.Enter<EndGameSessionState>();
            }
        }
    }
}