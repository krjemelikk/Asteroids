using Source.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Source.GameLogic.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private IMemoryPool _memoryPool;
        private float _elapsedTimeAfterSpawn;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public float LifeTime { get; set; }

        private void Update()
        {
            UpdateElapseTime();

            if (LifeTimeIsOver())
            {
                _memoryPool.Despawn(this);
            }
        }

        private void UpdateElapseTime() =>
            _elapsedTimeAfterSpawn += Time.deltaTime;

        private bool LifeTimeIsOver() =>
            _elapsedTimeAfterSpawn >= LifeTime;

        public class Pool : MemoryPool<Bullet>
        {
            private readonly IStaticDataService _staticData;

            public Pool(IStaticDataService staticData)
            {
                _staticData = staticData;
            }

            protected override void OnCreated(Bullet item)
            {
                base.OnCreated(item);

                var data = _staticData.ForBullet();
                item.LifeTime = data.LifeTime;
            }

            protected override void OnSpawned(Bullet item)
            {
                item._memoryPool = this;
                item.gameObject.SetActive(true);
            }

            protected override void OnDespawned(Bullet item)
            {
                item.gameObject.SetActive(false);
                item._elapsedTimeAfterSpawn = 0;
            }
        }
    }
}