using Source.Infrastructure.Services;
using Source.StaticData;
using UnityEngine;
using Zenject;

namespace Source.GameLogic.Asteroids
{
    public class AsteroidSpawner : ITickable
    {
        private readonly Asteroid.Pool _pool;
        private readonly IRandomService _randomService;

        private float _cooldown;
        public float SpawnRadius { get; set; }
        public float SpawnCooldown { get; set; }


        public AsteroidSpawner(Asteroid.Pool pool, IRandomService randomService, AsteroidSpawnerData data)
        {
            _randomService = randomService;
            _pool = pool;

            SpawnRadius = data.SpawnRadius;
            SpawnCooldown = data.SpawnCooldown;
        }

        public void Tick()
        {
            UpdateCooldown();

            if (CooldownIsUp())
            {
                Spawn(RandomPosition(SpawnRadius));
            }
        }


        private void Spawn(Vector3 position)
        {
            _pool.Spawn(position);
            ResetCooldown();
        }

        private Vector3 RandomPosition(float radius)
        {
            var angle = _randomService.Next(0, 2 * Mathf.PI);
            var sin = Mathf.Sin(angle);
            var cos = Mathf.Cos(angle);

            return new Vector3(cos * radius, sin * radius);
        }

        private bool CooldownIsUp() =>
            _cooldown <= 0;

        private void ResetCooldown() =>
            _cooldown = SpawnCooldown;

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _cooldown -= Time.deltaTime;
        }
    }
}