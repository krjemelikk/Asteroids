using UnityEngine;

namespace Source.Infrastructure.Services.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis =>
            new Vector2(SimpleInput.GetAxis(HorizontalAxis), SimpleInput.GetAxis(VerticalAxis));

        public override bool IsAttackButtonDown =>
            SimpleInput.GetButton(AttackButton);
    }
}