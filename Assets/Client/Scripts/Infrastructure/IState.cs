namespace Client.Scripts.Infrastructure
{
    public interface IState : IExitableState
    {
        void Enter();
        void Exit();
    }

    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
    
    public interface IExitableState
    {
        void Exit(); 
    }
    
}