using Source.Infrastructure.AssetManagement;
using Source.Infrastructure.Services.StaticData;

namespace Source.Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _dataService;

        public BootstrapState(IGameStateMachine gameStateMachine, IAssetProvider assetProvider, IStaticDataService dataService)
        {
            _gameStateMachine = gameStateMachine;
            _assetProvider = assetProvider;
            _dataService = dataService;
        }

        public void Enter()
        { 
            _assetProvider.Initialize();
            _dataService.Load();
            
            _gameStateMachine.Enter<LoadLevelState, string>(SceneName.Main);
        }

        public void Exit()
        {
            
        }
    }
}