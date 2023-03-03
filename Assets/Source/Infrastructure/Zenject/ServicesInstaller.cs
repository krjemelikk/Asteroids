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
    }
}