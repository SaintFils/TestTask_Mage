using UnityEngine;

namespace Client.Scripts.Services.Input
{
    public sealed class DesktopMouseInputService : DesktopAxisInputService
    {
        //public override Vector2 Axis => new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));

        public override float RotationInput => UnityEngine.Input.GetAxis(MouseX);

        public override bool IsAttackButtonUp()
        {
            throw new System.NotImplementedException();
        }
    }
}