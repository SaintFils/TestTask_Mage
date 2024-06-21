using Client.Scripts.Infrastructure.AssetManagement;
using UnityEngine;

namespace Client.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider assets;

        public GameFactory(IAssetProvider assets)
        {
            this.assets = assets;
        }
        
        public GameObject CreatePlayer(GameObject point) => assets.Instantiate(AssetPath.PlayerPath, point.transform.position);

        public void CreateHud() => assets.Instantiate(AssetPath.HudPath);
    }
} 