using UnityEngine;

namespace Client.Scripts.Infrastructure.Services.Input
{
    public abstract class DesktopAxisInputService : InputService
    {
        public override Vector2 Axis => new(UnityEngine.Input.GetAxisRaw(Horizontal), UnityEngine.Input.GetAxisRaw(Vertical));
    }
}