using Mono.Cecil;
using Source.GameLogic.Asteroids;
using UnityEngine;

namespace Source.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public Object ShipPrefab() =>
            Resources.Load<Object>(AssetAddress.ShipPrefabPath);

        public Object HUDPrefab() =>
            Resources.Load<Object>(AssetAddress.HUDPrefabPath);

        public Object AsteroidPrefab(AsteroidTypeId typeId) =>
            Resources.Load<Object>(AsteroidPrefabAddress(typeId));

        private string AsteroidPrefabAddress(AsteroidTypeId typeId)
        {
            switch (typeId)
            {
                case AsteroidTypeId.Asteroid:
                    return AssetAddress.Asteroid;
                case AsteroidTypeId.BigAsteroid:
                    return AssetAddress.BigAsteroid;
                default:
                    return null;
            }
        }
    }
}