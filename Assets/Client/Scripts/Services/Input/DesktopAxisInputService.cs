using UnityEngine;

namespace Client.Scripts.Services.Input
{
    public abstract class DesktopAxisInputService : InputService
    {
        public override Vector2 Axis => new(UnityEngine.Input.GetAxisRaw(Horizontal), UnityEngine.Input.GetAxisRaw(Vertical));

        public override bool IsAttackButtonUp()
        {
            throw new System.NotImplementedException();
        }
    }
}