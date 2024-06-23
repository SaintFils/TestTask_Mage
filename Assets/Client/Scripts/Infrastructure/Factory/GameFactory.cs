using System;
using System.Collections.Generic;
using Client.Scripts.Infrastructure.AssetManagement;
using Client.Scripts.Infrastructure.Services.Progress;
using UnityEngine;

namespace Client.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets assets;
        
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
        
        public GameObject PlayerGameObject { get; private set; }
        public event Action PlayerCreated;

        public GameFactory(IAssets assets)
        {
            this.assets = assets;
        }
        
        public GameObject CreatePlayer(GameObject point)
        {
            GameObject gameObject = assets.Instantiate(AssetPath.PlayerPath, point.transform.position + new Vector3(0, .5f, 0));

            RegisterProgressWatchers(gameObject); //part of placeholder for save/load progress feature

            PlayerGameObject = gameObject;
            PlayerCreated?.Invoke();
            
            return gameObject;
        }

        public GameObject CreateHud() => assets.Instantiate(AssetPath.HudPath);

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (var progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
    } 
} 