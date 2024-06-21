using UnityEngine;

namespace Client.Scripts.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }
        float RotationInput { get; }

        bool IsAttackButtonUp();
    }
}