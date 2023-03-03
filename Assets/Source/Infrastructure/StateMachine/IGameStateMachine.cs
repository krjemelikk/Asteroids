﻿using Source.Infrastructure.StateMachine.States;

namespace Source.Infrastructure.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : IState;
    }
}