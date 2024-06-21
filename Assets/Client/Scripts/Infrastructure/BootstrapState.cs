using Client.Scripts.Services.Input;

namespace Client.Scripts.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine stateMachine;
        private readonly SceneLoader sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() => stateMachine.Enter<LoadLevelState, string>("Main");

        private void RegisterServices()
        {
            Game.InputService = RegisterInputService();
        }

        public void Exit()
        {
            
        }

        private static IInputService RegisterInputService()
        {
            //here we can check platform and add service for our platform (mobile or PC for example)
            return new DesktopMouseInputService();
            //return new DesktopKeyboardInputService();
        }
    }
}