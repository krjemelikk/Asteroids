using Source.GameLogic.Asteroids;
using Source.StaticData;
using UnityEngine;

namespace Source.Infrastructure.Services
{
    class StaticDataService : IStaticDataService
    {
        private const string ShipDataPath = "StaticData/Ship";
        private const string BulletDataPath = "StaticData/Bullet";
        private const string AsteroidDataPath = "StaticData/Asteroid";
        private const string BigAsteroidDataPath = "StaticData/BigAsteroid";

        public ShipData ForShip() =>
            Resources.Load<ShipData>(ShipDataPath);

        public BulletData ForBullet() =>
            Resources.Load<BulletData>(BulletDataPath);

        public AsteroidData ForAsteroid(AsteroidTypeId id) =>
            Resources.Load<AsteroidData>(AsteroidPath(id));

        private string AsteroidPath(AsteroidTypeId id)
        {
            switch (id)
            {
                case AsteroidTypeId.Asteroid:
                    return AsteroidDataPath;
                case AsteroidTypeId.BigAsteroid:
                    return BigAsteroidDataPath;
                default:
                    return null;
            }
        }
    }
}