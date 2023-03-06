using Source.Infrastructure.Services;
using UnityEngine;
using Zenject;

public class ShipMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    private IInputService _inputService;

    public float Speed { get; set; }
    public float RotationSpeed { get; set; }

    [Inject]
    private void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }

    private void FixedUpdate()
    {
        Move(_inputService.Vertical);
        Rotate(_inputService.Horizontal);
    }

    private void Move(float vertical) =>
        _rigidbody.velocity = transform.up * vertical * Speed * Time.fixedDeltaTime;

    private void Rotate(float horizontal) =>
        transform.Rotate(-1 * transform.forward * horizontal * RotationSpeed * Time.fixedDeltaTime);
}