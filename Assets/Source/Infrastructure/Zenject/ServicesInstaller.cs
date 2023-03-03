using Source.Infrastructure.Services;
using Source.Infrastructure.StateMachine;
using Source.Infrastructure.StateMachine.States.Factory;
using Zenject;

namespace Source.Infrastructure.Zenject
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameStateMachine();

            StatesFactory();

            CoroutineRunner();

            SceneLoader();

            InputService();
        }

        private void GameStateMachine() =>
            Container.BindInterfacesTo<GameStateMachine>().AsSingle();

        private void StatesFactory() =>
            Container.BindInterfacesTo<StatesFactory>().AsSingle();

        private void CoroutineRunner()
        {
            Container
                .BindInterfacesTo<CoroutineRunner>()
                .FromComponentInNewPrefabResource(InfrastractureAssetPath.CoroutineRunner)
                .AsSingle();
        }

        private void SceneLoader() =>
            Container.BindInterfacesTo<SceneLoader>().AsSingle();

        private void InputService() =>
            Container.BindInterfacesTo<InputService>().AsSingle();
    }
}