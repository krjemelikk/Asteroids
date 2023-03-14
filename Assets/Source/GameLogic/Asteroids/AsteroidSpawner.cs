using System;
using Source.Infrastructure.Factory;
using Source.Infrastructure.Services;
using Source.Infrastructure.Zenject;
using Source.StaticData;
using UnityEngine;
using Zenject;

namespace Source.GameLogic.Asteroids
{
    public class AsteroidSpawner : ITickable
    {
        private readonly Array _asteroids;
        private readonly IGameFactory _gameFactory;
        private readonly IRandomService _randomService;

        private float _cooldown;
        public float SpawnRadius { get; set; }
        public float SpawnCooldown { get; set; }


        public AsteroidSpawner(IGameFactory gameFactory, IRandomService randomService, AsteroidSpawnerData data)
        {
            _asteroids = Enum.GetValues(typeof(AsteroidTypeId));
            _gameFactory = gameFactory;
            _randomService = randomService;

            SpawnRadius = data.SpawnRadius;
            SpawnCooldown = data.SpawnCooldown;
        }

        public void Tick()
        {
            UpdateCooldown();

            if (CooldownIsUp())
            {
                Spawn(RandomAsteroidType(), RandomPosition(SpawnRadius));
            }
        }


        private void Spawn(AsteroidTypeId typeId, Vector3 position)
        {
            _gameFactory.CreateAsteroid(typeId, position);
            ResetCooldown();
        }

        private Vector3 RandomPosition(float radius)
        {
            var angle = _randomService.Next(0, 2 * Mathf.PI);
            var sin = Mathf.Sin(angle);
            var cos = Mathf.Cos(angle);

            return new Vector3(cos * radius, sin * radius);
        }

        private AsteroidTypeId RandomAsteroidType() =>
            (AsteroidTypeId)_asteroids.GetValue(_randomService.Next(0, _asteroids.Length));

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