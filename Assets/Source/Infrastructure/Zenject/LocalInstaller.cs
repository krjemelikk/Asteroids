using Source.GameLogic.Asteroids;
using Source.GameLogic.Weapon;
using Source.Infrastructure.AssetManagement;
using Source.Infrastructure.Factory;
using Source.Infrastructure.Services;
using Source.StaticData;
using Zenject;

namespace Source.Infrastructure.Zenject
{
    public class LocalInstaller : MonoInstaller
    {
        private const string BulletPoolTransform = "BulletPool";

        public override void InstallBindings()
        {
            GameFactory();

            BulletPool();
            
            AsteroidSpawner(DataForSpawner());
        }

        private void GameFactory() =>
            Container.BindInterfacesTo<GameFactory>().AsSingle();

        private void BulletPool()
        {
            Container
                .BindMemoryPool<Bullet, Bullet.Pool>()
                .FromComponentInNewPrefabResource(AssetAddress.BulletPrefabPath)
                .UnderTransformGroup(BulletPoolTransform).AsSingle();
        }

        private void AsteroidSpawner(AsteroidSpawnerData data)
        {
            Container
                .BindInterfacesTo<AsteroidSpawner>()
                .AsSingle()
                .WithArguments(data);
        }

        private AsteroidSpawnerData DataForSpawner() =>
            Container.Resolve<IStaticDataService>().ForSpawner();
    }
}