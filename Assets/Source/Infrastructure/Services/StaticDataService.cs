using System.Collections.Generic;
using System.Linq;
using Source.GameLogic.Asteroids;
using Source.StaticData;
using UnityEngine;

namespace Source.Infrastructure.Services
{
    class StaticDataService : IStaticDataService
    {
        private const string ShipDataPath = "StaticData/Ship";
        private const string BulletDataPath = "StaticData/Bullet";
        private const string AsteroidsDataPath = "StaticData/Asteroids";
        private const string AsteroidSpawnerDataPath = "StaticData/AsteroidSpawner";

        private Dictionary<AsteroidTypeId, AsteroidData> _asteroids;

        public void Load()
        {
            LoadAsteroids();
        }

        public ShipData ForShip() =>
            Resources.Load<ShipData>(ShipDataPath);

        public BulletData ForBullet() =>
            Resources.Load<BulletData>(BulletDataPath);

        public AsteroidData ForAsteroid(AsteroidTypeId id) =>
            _asteroids.TryGetValue(id, out AsteroidData data) ? data : null;

        public AsteroidSpawnerData ForSpawner() =>
            Resources.Load<AsteroidSpawnerData>(AsteroidSpawnerDataPath);

        private void LoadAsteroids()
        {
            _asteroids = Resources
                .LoadAll<AsteroidData>(AsteroidsDataPath)
                .ToDictionary(x => x.AsteroidId, x => x);
        }
    }
}