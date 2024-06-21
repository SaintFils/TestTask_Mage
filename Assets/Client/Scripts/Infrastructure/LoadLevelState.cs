using Client.Scripts.CameraLogic;
using UnityEngine;

namespace Client.Scripts.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private const string PlayerPath = "Player/Player";
        private const string HudPath = "Hud/HUD";
        private readonly GameStateMachine gameStateMachine;
        private readonly SceneLoader sceneLoader;
        private readonly LoadingScreen loadingScreen;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingScreen loadingScreen)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            this.loadingScreen = loadingScreen;
        }

        public void Enter(string sceneName)
        {
            loadingScreen.Show();
            sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() => loadingScreen.Hide();

        private void OnLoaded()
        {
            GameObject initialPoint = GameObject.FindWithTag(InitialPointTag);
            GameObject player = Instantiate(PlayerPath, initialPoint.transform.position);
            
            Instantiate(HudPath);
            
            CameraFollow(player);
            
            gameStateMachine.Enter<GameLoopState>();
        }

        private static void CameraFollow(GameObject player)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(player);
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        
        private static GameObject Instantiate(string path, Vector3 point)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, point, Quaternion.identity);
        }
    }
}