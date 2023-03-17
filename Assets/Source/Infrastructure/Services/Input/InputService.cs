using UnityEngine;

namespace Source.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        public float Horizontal =>
            UnityEngine.Input.GetAxis(HorizontalAxis);

        public float Vertical =>
            UnityEngine.Input.GetAxis(VerticalAxis);

        public bool IsAttackButtonDown =>
            UnityEngine.Input.GetKey(KeyCode.Space);
    }
}