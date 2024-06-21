using UnityEngine;

namespace Client.Scripts.Infrastructure.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string HorizontalArrows = "HorizontalArrows";
        protected const string MouseX = "Mouse X";
        
        public abstract Vector2 Axis { get; }
        public virtual float RotationInput { get; }

        public abstract bool IsAttackButtonUp();
    }
}