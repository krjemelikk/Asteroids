using Source.GameLogic;
using Source.Infrastructure.Services;

namespace Source.Infrastructure.StateMachine.States
{
    public class LoadLevelState : IConfigurableState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadLevelState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }
        
        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.LoadScene(sceneName, onLoaded);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        private void onLoaded()
        {
            
        }
    }
}