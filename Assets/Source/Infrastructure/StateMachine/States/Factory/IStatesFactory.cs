namespace Source.Infrastructure.StateMachine.States.Factory
{
    public interface IStatesFactory
    {
        IExitableState Create<TState>() where TState : IExitableState;
    }
}