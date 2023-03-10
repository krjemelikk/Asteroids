using Source.GameLogic.Asteroids;
using UnityEngine;

namespace Source.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        Object ShipPrefab();
        Object HUDPrefab();
        Object AsteroidPrefab(AsteroidTypeId typeId);
    }
}