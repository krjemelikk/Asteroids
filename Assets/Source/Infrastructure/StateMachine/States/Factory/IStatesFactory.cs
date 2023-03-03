namespace Source.Infrastructure.StateMachine.States.Factory
{
    public interface IStatesFactory
    {
        IState Create<TState>() where TState : IState;
    }
}