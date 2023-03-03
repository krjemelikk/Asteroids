namespace Source.Infrastructure.StateMachine.States
{
    public interface IState
    {
        void Exit();
        void Enter();
    }
}