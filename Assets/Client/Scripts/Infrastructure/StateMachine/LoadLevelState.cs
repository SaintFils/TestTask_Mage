using Client.Scripts.CameraLogic;
using Client.Scripts.Infrastructure.Factory;
using UnityEngine;

namespace Client.Scripts.Infrastructure.StateMachine
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        
        private readonly GameStateMachine gameStateMachine;
        private readonly SceneLoader sceneLoader;
        private readonly LoadingScreen loadingScreen;
        private readonly IGameFactory gameFactory;

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
            GameObject player = gameFactory.CreatePlayer(GameObject.FindWithTag(InitialPointTag));
            
            gameFactory.CreateHud();
            
            CameraFollow(player);
            
            gameStateMachine.Enter<GameLoopState>();
        }

        private static void CameraFollow(GameObject player)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(player);
        }
    }
}