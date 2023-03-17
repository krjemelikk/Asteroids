using Source.GameLogic.Asteroids;
using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Asteroid", fileName = "Asteroid")]
    public class AsteroidData : ScriptableObject
    {
        public AsteroidTypeId AsteroidId;
        public Vector3 Scale;
        public float LifeTime;
        public float Damage;
        public float MaxSpeed;
        public float MinSpeed;
    }
}