using UnityEngine;

namespace Source.Infrastructure.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis =>
            new Vector2(UnityEngine.Input.GetAxis(HorizontalAxis), UnityEngine.Input.GetAxis(VerticalAxis));

        public override bool IsAttackButtonDown =>
            UnityEngine.Input.GetKey(KeyCode.Space);
    }
}