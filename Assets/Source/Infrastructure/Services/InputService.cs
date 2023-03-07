using UnityEngine;

namespace Source.Infrastructure.Services
{
    public class InputService : IInputService
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        public float Horizontal =>
            Input.GetAxis(HorizontalAxis);
        
        public float Vertical =>
            Input.GetAxis(VerticalAxis);

        public bool IsAttackButtonDown =>
            Input.GetKey(KeyCode.Space);
    }
}