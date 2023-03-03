using System;
using System.Collections.Generic;
using Source.Infrastructure.StateMachine.States;
using Zenject;

namespace Source.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine, IInitializable
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>();
        }
        
        public void Initialize()
        {
            _states.Add(typeof(BootstrapState), new BootstrapState());
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