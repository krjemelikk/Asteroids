using System;
using Source.GameLogic.Ship;
using Source.Infrastructure.Services.Random;
using Source.Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Source.GameLogic.Asteroids
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private AsteroidMove _move;
        private IMemoryPool _memoryPool;

        private float _elapsedTimeAfterSpawn;
        private bool _isActive;

        public float LifeTime { get; set; }
        public float Damage { get; set; }

        private void Update()
        {
            UpdateElapseTime();

            if (LifeTimeIsOver() && _memoryPool != null)
            {
                _memoryPool.Despawn(this);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IHealth>(out IHealth ship) && _isActive)
            {
                if (_memoryPool != null)
                {
                    ship.TakeDamage(Damage);
                    _memoryPool.Despawn(this);
                }
            }
        }

        private void UpdateElapseTime() =>
            _elapsedTimeAfterSpawn += Time.deltaTime;

        private bool LifeTimeIsOver() =>
            _elapsedTimeAfterSpawn >= LifeTime;

        private void Reset() =>
            _elapsedTimeAfterSpawn = 0;

        public class Pool : MemoryPool<Vector3, Asteroid>
        {
            private readonly Array _asteroids;
            private readonly IStaticDataService _staticData;
            private readonly IRandomService _randomService;

            public Pool(IStaticDataService staticData, IRandomService randomService)
            {
                _asteroids = Enum.GetValues(typeof(AsteroidTypeId));
                _staticData = staticData;
                _randomService = randomService;
            }

            protected override void OnCreated(Asteroid item)
            {
                var randomType = RandomAsteroidType();
                var asteroidData = _staticData.ForAsteroid(randomType);

                var asteroidComponent = item.GetComponent<Asteroid>();
                asteroidComponent.Damage = asteroidData.Damage;
                asteroidComponent.LifeTime = asteroidData.LifeTime;

                var asteroidMove = item.GetComponent<AsteroidMove>();
                asteroidMove.MaxSpeed = asteroidData.MaxSpeed;
                asteroidMove.MinSpeed = asteroidData.MinSpeed;

                item.transform.localScale = asteroidData.Scale;
            }

            protected override void Reinitialize(Vector3 position, Asteroid item)
            {
                item.transform.position = position;
                item._move.Move();
            }

            protected override void OnSpawned(Asteroid item)
            {
                item._isActive = true;
                item._memoryPool = this;
                item.gameObject.SetActive(true);
            }

            protected override void OnDespawned(Asteroid item)
            {
                item._isActive = false;
                item._memoryPool = null;
                item.gameObject.SetActive(false);
                item.Reset();
            }

            private AsteroidTypeId RandomAsteroidType() =>
                (AsteroidTypeId)_asteroids.GetValue(_randomService.Next(0, _asteroids.Length));
        }
    }
}