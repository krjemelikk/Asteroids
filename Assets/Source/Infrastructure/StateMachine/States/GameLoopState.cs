using Source.Infrastructure.Services;
using Zenject;

namespace Source.Infrastructure.StateMachine.States
{
    public class GameLoopState : IConfigurableState<GameSessionConfig>, ITickable
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IGameplayModeService _gameplayModeService;

        public GameLoopState(IGameStateMachine stateMachine, IGameplayModeService gameplayModeService)
        {
            _stateMachine = stateMachine;
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
                _stateMachine.Enter<EndGameSessionState>();
            }
        }
    }
}