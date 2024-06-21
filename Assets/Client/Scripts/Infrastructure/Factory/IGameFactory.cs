using UnityEngine;

namespace Client.Scripts.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreatePlayer(GameObject point);
        void CreateHud();
    }
}