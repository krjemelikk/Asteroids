using Source.GameLogic.Weapon;
using Source.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Source.GameLogic.Ship
{
    public class ShipAttack : MonoBehaviour
    {
        private IInputService _inputService;
        private Bullet.Pool _bulletPool;
        private float _cooldown;

        public float AttackCoolDown { get; set; }
        public float ShotForce { get; set; }

        [Inject]
        private void Construct(IInputService inputService, Bullet.Pool bulletPool)
        {
            _inputService = inputService;
            _bulletPool = bulletPool;
        }

        private void Update()
        {
            UpdateCooldown();

            if (_inputService.IsAttackButtonDown && CanAttack())
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            var bullet = _bulletPool.Spawn();

            SetPosition(bullet);
            bullet.Rigidbody2D.AddForce(transform.up * ShotForce);

            ResetCooldown();
        }

        private bool CanAttack() =>
            CooldownIsUp();

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _cooldown -= Time.deltaTime;
        }

        private bool CooldownIsUp() =>
            _cooldown <= 0;

        private void ResetCooldown() =>
            _cooldown = AttackCoolDown;

        private void SetPosition(Bullet bullet)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
        }
    }
}