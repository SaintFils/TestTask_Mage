﻿using UnityEngine;

namespace Client.Scripts.Services.Input
{
    public sealed class DesktopKeyboardInputService : DesktopAxisInputService
    {
        public override float RotationInput => UnityEngine.Input.GetAxis(HorizontalArrows);

        public override bool IsAttackButtonUp()
        {
            throw new System.NotImplementedException();
        }
    }
}