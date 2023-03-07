using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Ship", fileName = "Ship")]
    public class ShipData : ScriptableObject
    {
        public float Speed;
        public float RotationSpeed;
        public float AttackCoolDown;
        public float ShotForce;
    }
}