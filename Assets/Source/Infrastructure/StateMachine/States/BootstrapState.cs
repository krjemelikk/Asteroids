using Source.Infrastructure.AssetManagement;
using Source.Infrastructure.Services;

namespace Source.Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IAssetProvider _assetProvider;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(IGameStateMachine gameStateMachine, IAssetProvider assetProvider, ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _assetProvider = assetProvider;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        { 
            _assetProvider.Initialize();
            
            _gameStateMachine.Enter<LoadLevelState, string>(SceneName.Main);
        }

        public void Exit()
        {
            
        }
    }
}