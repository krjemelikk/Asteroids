using Source.Infrastructure.AssetManagement;
using Source.Infrastructure.Services;
using Source.Infrastructure.Services.Input;
using Source.Infrastructure.Services.Random;
using Source.Infrastructure.Services.StaticData;
using Source.Infrastructure.StateMachine;
using Source.Infrastructure.StateMachine.States.Factory;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure.Zenject
{
    public class GameInstaller : MonoInstaller
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

            GameplayModeService();

            GameOverScreen();
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

        private void InputService()
        {
            if (Application.isEditor)
                Container.BindInterfacesTo<StandaloneInputService>().AsSingle();

            else
                Container.BindInterfacesTo<MobileInputService>().AsSingle();
        }

        private void SceneLoader() =>
            Container.BindInterfacesTo<SceneLoader>().AsSingle();

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

        private void GameplayModeService() =>
            Container.BindInterfacesTo<GameplayModeService>().AsSingle();

        private void GameOverScreen()
        {
            Container
                .Bind<GameOverScreen>()
                .FromComponentInNewPrefabResource(InfrastractureAssetPath.GameOverScreen)
                .AsSingle();
        }
    }
}