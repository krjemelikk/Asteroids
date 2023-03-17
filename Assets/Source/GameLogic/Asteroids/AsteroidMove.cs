using Source.Infrastructure.Services.Random;
using UnityEngine;
using Zenject;

namespace Source.GameLogic.Asteroids
{
    public class AsteroidMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        private IRandomService _randomService;

        public float MaxSpeed { get; set; }
        public float MinSpeed { get; set; }

        [Inject]
        private void Construct(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public void Move() =>
            _rigidbody.AddForce(MoveDirection() * RandomSpeed(MinSpeed, MaxSpeed));

        private Vector3 MoveDirection() =>
            (RandomPosition() - transform.position).normalized;

        private Vector3 RandomPosition()
        {
            var angle = _randomService.Next(0, 2 * Mathf.PI);
            var sin = Mathf.Sin(angle);
            var cos = Mathf.Cos(angle);

            return new Vector3(cos, sin);
        }

        private float RandomSpeed(float minSpeed, float maxSpeed) =>
            _randomService.Next(minSpeed, maxSpeed);
    }
}