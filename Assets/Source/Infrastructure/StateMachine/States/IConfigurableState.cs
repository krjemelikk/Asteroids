namespace Source.Infrastructure.StateMachine.States
{
    public interface IConfigurableState<TConfig> : IExitableState
    {
        void Enter(TConfig config);
    }
}