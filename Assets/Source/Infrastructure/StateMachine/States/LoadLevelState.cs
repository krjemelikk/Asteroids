using Source.Infrastructure.Services;

namespace Source.Infrastructure.StateMachine.States
{
    public class LoadLevelState : IConfigurableState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter(string sceneName)
        {
            _sceneLoader.LoadScene(sceneName, onLoaded);
        }

        public void Exit()
        {
            
        }

        private void onLoaded()
        {
            
        }
    }
}