using Zenject;

namespace Source.Infrastructure.StateMachine.States.Factory
{
    public class StatesFactory : IStatesFactory
    {
        private readonly IInstantiator _instantiator;

        public StatesFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public IState Create<TState>() where TState : IState
        {
            return _instantiator.Instantiate<TState>();
        }
    }
}