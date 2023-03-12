using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Asteroid", fileName = "Asteroid")]
    public class AsteroidData : ScriptableObject
    {
        public float LifeTime;
        public float Damage;
        public float MaxSpeed;
        public float MinSpeed;
    }
}