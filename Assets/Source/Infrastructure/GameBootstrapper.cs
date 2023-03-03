using Source.Infrastructure.StateMachine;
using Source.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}