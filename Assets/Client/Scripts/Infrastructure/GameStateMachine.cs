
using System;
using System.Collections.Generic;

namespace Client.Scripts.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type,IExitableState> states;
        private IExitableState activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingScreen loadingScreen)
        {
            states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadingScreen),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }


        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }
        
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            activeState?.Exit();
            
            TState state = GetState<TState>();
            activeState = state;
            
            return state;
        }
        
        //this downcast is just easy way here because GetState knows what type it get in parameter exactly.
        //So, looks ugly, but why not. Could be refactored
        private TState GetState<TState>() where TState : class, IExitableState => states[typeof(TState)] as TState;
    }
}