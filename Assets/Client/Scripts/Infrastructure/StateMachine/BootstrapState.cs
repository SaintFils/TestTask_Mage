using Client.Scripts.Infrastructure.AssetManagement;
using Client.Scripts.Infrastructure.Factory;
using Client.Scripts.Infrastructure.Services;
using Client.Scripts.Infrastructure.Services.Input;
using Client.Scripts.Infrastructure.Services.Progress;

namespace Client.Scripts.Infrastructure.StateMachine
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine stateMachine;
        private readonly SceneLoader sceneLoader;
        private readonly ServiceLocator services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ServiceLocator services)
        {
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
            this.services = services;
            
            RegisterServices();
        }

        public void Enter()
        {
            sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }
        
        public void Exit()
        {
        }

        private void EnterLoadLevel() => stateMachine.Enter<LoadProgressState>();

        private void RegisterServices()
        {
            services.RegisterSingle<IInputService>(InputService());
            services.RegisterSingle<IAssets>(new AssetProvider());
            services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            services.RegisterSingle<ISaveLoadService>(new SaveLoadService(services.Single<IPersistentProgressService>(), services.Single<IGameFactory>()));
            services.RegisterSingle<IGameFactory>(new GameFactory(services.Single<IAssets>()));
        }

        private static IInputService InputService()
        {
            //here we can check platform and add service for our platform (mobile or PC for example)
            return new DesktopMouseInputService();
            //return new DesktopKeyboardInputService();
        }
    }
}