using System;
using System.Collections.Generic;
using Client.Scripts.Infrastructure.Services;
using Client.Scripts.Infrastructure.Services.Progress;
using UnityEngine;

namespace Client.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject point);
        GameObject CreateHud();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        GameObject PlayerGameObject { get; }
        event Action PlayerCreated;
        void Cleanup();
    }
}