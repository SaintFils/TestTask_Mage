﻿namespace Client.Scripts.Infrastructure.Services.Input
{
    public sealed class DesktopMouseInputService : DesktopAxisInputService
    {
        public override float RotationInput => UnityEngine.Input.GetAxis(MouseX);

        public override bool IsAttackButtonUp()
        {
            throw new System.NotImplementedException();
        }
    }
}