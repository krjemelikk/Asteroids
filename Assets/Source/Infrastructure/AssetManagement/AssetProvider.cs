using Mono.Cecil;
using UnityEngine;

namespace Source.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public Object ShipPrefab() =>
            Resources.Load<Object>(AssetAddress.ShipPrefabPath);

        public Object HUDPrefab() =>
            Resources.Load<Object>(AssetAddress.HUDPrefabPath);
    }
}