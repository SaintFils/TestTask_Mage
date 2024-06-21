using Client.Scripts.Data;
using Client.Scripts.Infrastructure.Services.Progress;

namespace Client.Scripts.Infrastructure.StateMachine
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly IPersistentProgressService progressService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService)
        {
            this.gameStateMachine = gameStateMachine;
            this.progressService = progressService;
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
           progressService.Progress = new PlayerProgress("Main"); //placeholder
        }
    }
}