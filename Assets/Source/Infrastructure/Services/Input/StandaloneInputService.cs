using UnityEngine;

namespace Source.Infrastructure.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override float Horizontal =>
            UnityEngine.Input.GetAxis(HorizontalAxis);

        public override float Vertical =>
            UnityEngine.Input.GetAxis(VerticalAxis);

        public override bool IsAttackButtonDown =>
            UnityEngine.Input.GetKey(KeyCode.Space);
    }
}