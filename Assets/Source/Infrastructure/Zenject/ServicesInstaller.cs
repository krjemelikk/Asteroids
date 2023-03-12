using Source.GameLogic;
using Source.Infrastructure.AssetManagement;
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

            AssetProvider();

            StaticData();

            RandomService();

            LoadingCurtain();
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

        private void AssetProvider() =>
            Container.BindInterfacesTo<AssetProvider>().AsSingle();

        private void StaticData() =>
            Container.BindInterfacesTo<StaticDataService>().AsSingle();

        private void RandomService() =>
            Container.BindInterfacesTo<RandomService>().AsSingle();

        private void LoadingCurtain()
        {
            Container
                .Bind<LoadingCurtain>()
                .FromComponentInNewPrefabResource(InfrastractureAssetPath.LoadingCurtain)
                .AsSingle();
        }
    }
}