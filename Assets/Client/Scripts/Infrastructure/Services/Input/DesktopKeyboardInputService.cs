using UnityEngine;

namespace Client.Scripts.Infrastructure.Services.Input
{
    public sealed class DesktopKeyboardInputService : DesktopAxisInputService
    {
        public override float RotationInput => UnityEngine.Input.GetAxis(HorizontalArrows);

        public override bool IsAttackButtonPressed() => UnityEngine.Input.GetKeyDown(KeyCode.X);
    }
}