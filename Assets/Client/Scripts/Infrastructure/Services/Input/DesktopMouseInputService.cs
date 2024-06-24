using UnityEngine;

namespace Client.Scripts.Infrastructure.Services.Input
{
    public sealed class DesktopMouseInputService : DesktopAxisInputService
    {
        public override float RotationInput => UnityEngine.Input.GetAxis(MouseX);

        public override bool IsAttackButtonPressed()
        {
            return UnityEngine.Input.GetMouseButtonDown(0) || UnityEngine.Input.GetKeyDown(KeyCode.E);
        }
    }
}