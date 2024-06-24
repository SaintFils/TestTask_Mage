using Client.Scripts.Infrastructure.Services;
using Client.Scripts.Infrastructure.StateMachine;
using Client.Scripts.Logic;

namespace Client.Scripts.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingScreen loadingScreen)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingScreen, ServiceLocator.Container);
        }
    }
    
}
