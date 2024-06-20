using UnityEngine;

namespace Client.Scripts.Services.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }
        float RotationInput { get; }

        bool IsAttackButtonUp();
    }
}