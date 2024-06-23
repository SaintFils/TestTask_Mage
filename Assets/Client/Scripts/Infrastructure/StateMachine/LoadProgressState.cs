using Client.Scripts.Data;
using Client.Scripts.Infrastructure.Services;
using Client.Scripts.Infrastructure.Services.Progress;

namespace Client.Scripts.Infrastructure.StateMachine
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly IPersistentProgressService progressService;
        private readonly ISaveLoadService saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            this.gameStateMachine = gameStateMachine;
            this.progressService = progressService;
            this.saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            gameStateMachine.Enter<LoadLevelState, string>(progressService.Progress.WorldData.PositionOnLevel.Level);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
           progressService.Progress = saveLoadService.LoadProgress() ?? NewProgress(); //placeholder
        }

        private static PlayerProgress NewProgress()
        {
            PlayerProgress playerProgress = new PlayerProgress(initialLevel: "Main");
            
            playerProgress.HealthStatus.MaxHealth = 50;
            playerProgress.HealthStatus.ResetHealth();
            playerProgress.HealthStatus.Armor = 1;
            
            return playerProgress;
        }
    }
}