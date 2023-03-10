using Source.GameLogic.Asteroids;
using Source.GameLogic.Ship;
using Source.Infrastructure.AssetManagement;
using Source.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _diContainer;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        public GameFactory(DiContainer diContainer, IAssetProvider assetProvider,
            IStaticDataService staticDataService)
        {
            _diContainer = diContainer;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public GameObject CreateShip(Vector3 at)
        {
            var shipPrefab = _assetProvider.ShipPrefab();
            var ship = _diContainer.InstantiatePrefab(shipPrefab, at, Quaternion.identity, null);

            var shipData = _staticDataService.ForShip();

            var shipMove = ship.GetComponent<ShipMove>();
            shipMove.Speed = shipData.Speed;
            shipMove.RotationSpeed = shipData.RotationSpeed;

            var shipAttack = ship.GetComponent<ShipAttack>();
            shipAttack.AttackCoolDown = shipData.AttackCoolDown;
            shipAttack.ShotForce = shipData.ShotForce;

            var shipHealth = ship.GetComponent<ShipHealth>();
            shipHealth.MaxHp = shipData.HP;
            shipHealth.CurrentHp = shipData.HP;

            _diContainer.Bind<IHealth>().FromInstance(shipHealth);

            return ship;
        }

        public GameObject CreateHUD()
        {
            var hudPrefab = _assetProvider.HUDPrefab();
            return _diContainer.InstantiatePrefab(hudPrefab);
        }

        public GameObject CreateAsteroid(AsteroidTypeId id, Vector3 at)
        {
            var asteroidPrefab = _assetProvider.AsteroidPrefab(id);
            var asteroid = _diContainer.InstantiatePrefab(asteroidPrefab, at, Quaternion.identity, null);

            var asteroidData = _staticDataService.ForAsteroid(id);

            var asteroidComponent = asteroid.GetComponent<Asteroid>();
            asteroidComponent.Damage = asteroidData.Damage;
            asteroidComponent.LifeTime = asteroidData.LifeTime;

            var asteroidMove = asteroid.GetComponent<AsteroidMove>();
            asteroidMove.MaxSpeed = asteroidData.MaxSpeed;
            asteroidMove.MinSpeed = asteroidData.MinSpeed;

            return asteroid;
        }
    }
}