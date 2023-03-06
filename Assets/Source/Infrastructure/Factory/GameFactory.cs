using Source.GameLogic.Ship;
using Source.Infrastructure.AssetManagement;
using Source.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        public GameFactory(IInstantiator instantiator, IAssetProvider assetProvider,
            IStaticDataService staticDataService)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public GameObject CreateShip(Vector3 at)
        {
            var shipPrefab = _assetProvider.ShipPrefab();
            var ship = _instantiator.InstantiatePrefab(shipPrefab, at, Quaternion.identity, null);

            var shipData = _staticDataService.ForShip();

            var shipMove = ship.GetComponent<ShipMove>();
            shipMove.Speed = shipData.Speed;
            shipMove.RotationSpeed = shipData.RotationSpeed;

            return ship;
        }
    }
}