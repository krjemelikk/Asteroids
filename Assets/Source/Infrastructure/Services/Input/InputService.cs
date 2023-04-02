using UnityEngine;

namespace Source.Infrastructure.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string HorizontalAxis = "Horizontal";
        protected const string VerticalAxis = "Vertical";
        protected const string AttackButton = "Attack";
        
        public abstract bool IsAttackButtonDown { get; }
        public abstract Vector2 Axis { get; }
    }
}