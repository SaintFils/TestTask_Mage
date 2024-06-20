using UnityEngine;

namespace Client.Scripts.Services.Input
{
    public sealed class DesktopKeyboardInputService : DesktopAxisInputService
    {
        //public override Vector2 Axis => new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));

        public override float RotationInput => UnityEngine.Input.GetAxis(HorizontalArrows);

        public override bool IsAttackButtonUp()
        {
            throw new System.NotImplementedException();
        }
    }
}