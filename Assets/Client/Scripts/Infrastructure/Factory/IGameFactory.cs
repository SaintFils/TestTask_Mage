using Client.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Client.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject point);
        void CreateHud();
    }
}