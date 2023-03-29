namespace Source.Infrastructure.Services.Input
{
    public class MobileInputService : InputService
    {
        public override float Horizontal =>
            SimpleInput.GetAxis(HorizontalAxis);

        public override float Vertical =>
            SimpleInput.GetAxis(VerticalAxis);

        public override bool IsAttackButtonDown =>
            SimpleInput.GetButton(AttackButton);
    }
}