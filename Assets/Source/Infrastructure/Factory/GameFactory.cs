using System.Threading.Tasks;
using Source.GameLogic.Ship;
using Source.Infrastructure.AssetManagement;
using Source.Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _diContainer;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;

        public GameFactory(DiContainer diContainer, IAssetProvider assetProvider, IStaticDataService staticData)
        {
            _diContainer = diContainer;
            _assetProvider = assetProvider;
            _staticData = staticData;
        }

        public async Task<GameObject> CreateShip(Vector3 at)
        {
            var shipPrefab = await _assetProvider.Load<Object>(AssetAddress.ShipPrefabPath);
            var ship = _diContainer.InstantiatePrefab(shipPrefab, at, Quaternion.identity, null);

            var shipData = _staticData.ForShip();

            var shipMove = ship.GetComponent<ShipMove>();
            shipMove.Speed = shipData.Speed;
            shipMove.RotationSpeed = shipData.RotationSpeed;

            var shipAttack = ship.GetComponent<ShipAttack>();
            shipAttack.AttackCoolDown = shipData.AttackCoolDown;
            shipAttack.ShotForce = shipData.ShotForce;

            var shipHealth = ship.GetComponent<ShipHealth>();
            shipHealth.MaxHp = shipData.HP;
            shipHealth.CurrentHp.Value = shipData.HP;

            return ship;
        }

        public async Task<GameObject> CreateHUD()
        {
            var hudPrefab = await _assetProvider.Load<Object>(AssetAddress.HUDPrefabPath);
            return _diContainer.InstantiatePrefab(hudPrefab);
        }
    }
}