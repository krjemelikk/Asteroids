using System;
using System.Collections.Generic;
using Source.Infrastructure.StateMachine.States;
using Source.Infrastructure.StateMachine.States.Factory;
using Zenject;

namespace Source.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine, IInitializable
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private readonly IStatesFactory _statesFactory;

        private IExitableState _activeState;

        public GameStateMachine(IStatesFactory statesFactory)
        {
            _statesFactory = statesFactory;
            _states = new Dictionary<Type, IExitableState>();
        }

        public void Initialize()
        {
            RegisterState<BootstrapState>();
            RegisterState<LoadLevelState>();
            RegisterState<GameLoopState>();
        }

        public void Enter<TState>() where TState : IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TConfig>(TConfig config) where TState : IConfigurableState<TConfig>
        {
            var state = ChangeState<TState>();
            state.Enter(config);
        }

        private TState ChangeState<TState>() where TState : IExitableState
        {
            var state = GetState<TState>();
            _activeState?.Exit();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : IExitableState =>
            (TState)_states[typeof(TState)];

        private void RegisterState<TState>() where TState : IExitableState =>
            _states.Add(typeof(TState), _statesFactory.Create<TState>());
    }
}