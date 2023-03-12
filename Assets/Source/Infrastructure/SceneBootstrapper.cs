using Source.Infrastructure.Factory;
using Source.Infrastructure.StateMachine;
using Source.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure
{
    public class SceneBootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform InitialPoint;

        private IGameStateMachine _gameStateMachine;
        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }

        private void Start()
        {
            InitGameWorld();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            InitShip();
            InitHUD();
        }

        private void InitShip() =>
            _gameFactory.CreateShip(InitialPoint.position);

        private void InitHUD() =>
            _gameFactory.CreateHUD();
    }
}