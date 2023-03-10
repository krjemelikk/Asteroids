using Source.GameLogic.Asteroids;
using Source.GameLogic.Weapon;
using Source.Infrastructure.AssetManagement;
using Source.Infrastructure.Factory;
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

            AsteroidSpawner();
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

        private void AsteroidSpawner() =>
            Container.BindInterfacesTo<AsteroidSpawner>().AsSingle();
    }
}