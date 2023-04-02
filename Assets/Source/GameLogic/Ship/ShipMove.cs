using Source.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Source.GameLogic.Ship
{
    public class ShipMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        private IInputService _inputService;

        public float Speed { get; set; }

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void FixedUpdate()
        {
            if (_inputService.Axis.sqrMagnitude > 0.001f)
                Rotate(_inputService.Axis);

            Move(_inputService.Axis);
        }

        private void Move(Vector2 axis) =>
            _rigidbody.velocity = axis * Speed * Time.fixedDeltaTime;

        private void Rotate(Vector2 moveVector) =>
            transform.up = moveVector;
    }
}