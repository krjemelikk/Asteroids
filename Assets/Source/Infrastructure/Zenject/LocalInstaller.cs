using Source.GameLogic.Asteroids;
using Source.GameLogic.Weapon;
using Source.Infrastructure.AssetManagement;
using Source.Infrastructure.Factory;
using Source.StaticData;
using Zenject;

namespace Source.Infrastructure.Zenject
{
    public class LocalInstaller : MonoInstaller
    {
        private const string BulletPoolTransform = "BulletPool";
        private const string AsteroidPoolTransform = "AsteroidPool";

        public override void InstallBindings()
        {
            GameFactory();

            BulletPool();

            AsteroidSpawner(DataForSpawner());
         
            AsteroidPool();
        }

        private void GameFactory() =>
            Container.BindInterfacesTo<GameFactory>().AsSingle();

        private void BulletPool()
        {
            Container
                .BindMemoryPool<Bullet, Bullet.Pool>()
                .FromComponentInNewPrefabResource(AssetAddress.BulletPrefabPath)
                .UnderTransformGroup(BulletPoolTransform);
        }
        
        private void AsteroidPool()
        {
            Container
                .BindMemoryPool<Asteroid, Asteroid.Pool>()
                .FromComponentInNewPrefabResource(AssetAddress.AsteroidPrefabPath)
                .UnderTransformGroup(AsteroidPoolTransform);
        }

        private void AsteroidSpawner(AsteroidSpawnerData data)
        {
            Container
                .BindInterfacesTo<AsteroidSpawner>()
                .AsSingle()
                .WithArguments(data);
        }

        private AsteroidSpawnerData DataForSpawner()
        {
            var data = new AsteroidSpawnerData();
            data.SpawnRadius = 15;
            data.SpawnCooldown = 0.5f;

            return data;
        }
    }
}