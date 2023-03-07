using Source.StaticData;
using UnityEngine;

namespace Source.Infrastructure.Services
{
    class StaticDataService : IStaticDataService
    {
        private const string ShipDataPath = "StaticData/Ship";
        private const string BulletDataPath = "StaticData/Bullet";

        public ShipData ForShip() =>
            Resources.Load<ShipData>(ShipDataPath);

        public BulletData ForBullet() =>
            Resources.Load<BulletData>(BulletDataPath);
    }
}