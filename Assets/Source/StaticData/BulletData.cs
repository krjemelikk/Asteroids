using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Bullet", fileName = "Bullet")]
    public class BulletData : ScriptableObject
    {
        public float LifeTime;
    }
}