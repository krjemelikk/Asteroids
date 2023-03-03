using System;
using System.Collections.Generic;
using Source.Infrastructure.StateMachine.States;
using Source.Infrastructure.StateMachine.States.Factory;
using Zenject;

namespace Source.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine, IInitializable
    {
        private readonly Dictionary<Type, IState> _states;
        private readonly IStatesFactory _statesFactory;
        
        private IState _activeState;

        public GameStateMachine(IStatesFactory statesFactory)
        {
            _statesFactory = statesFactory;
            _states = new Dictionary<Type, IState>();
        }
        
        public void Initialize()
        {
            _states.Add(typeof(BootstrapState), _statesFactory.Create<BootstrapState>());
        }

        public void Enter<TState>() where TState : IState
        {
            var state = _states[typeof(TState)];
            _activeState?.Exit(); 
            _activeState = state;
            
            state.Enter();
        }
    }
}