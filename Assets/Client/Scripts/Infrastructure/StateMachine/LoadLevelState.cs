using Client.Scripts.CameraLogic;
using Client.Scripts.Infrastructure.Factory;
using Client.Scripts.Infrastructure.Services.Progress;
using Client.Scripts.Logic;
using Client.Scripts.Player;
using Client.Scripts.UI;
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
        private readonly IPersistentProgressService progressService;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingScreen loadingScreen, IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            this.loadingScreen = loadingScreen;
            this.gameFactory = gameFactory;
            this.progressService = progressService;
        }

        public void Enter(string sceneName)
        {
            loadingScreen.Show();
            gameFactory.Cleanup();
            sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() => loadingScreen.Hide();

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();

            gameStateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in gameFactory.ProgressReaders)
                progressReader.LoadProgress(progressService.Progress);
        }

        private void InitGameWorld()
        {
            GameObject player = gameFactory.CreatePlayer(GameObject.FindWithTag(InitialPointTag));
            
            InitHud(player);
            CameraFollow(player);
        }

        private void InitHud(GameObject player)
        {
            GameObject hud = gameFactory.CreateHud();

            hud.GetComponentInChildren<ActorUI>().Construct(player.GetComponent<IHealth>());
        }

        private static void CameraFollow(GameObject player)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(player);
        }
    }
}