using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/AsteroidSpawner", fileName = "AsteroidSpawner")]
    public class AsteroidSpawnerData : ScriptableObject
    {
        public float SpawnRadius;
        public float SpawnCooldown;
    }
}