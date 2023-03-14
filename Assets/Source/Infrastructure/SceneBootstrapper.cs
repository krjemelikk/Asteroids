using Source.GameLogic.Asteroids;
using Source.GameLogic.Ship;
using Source.Infrastructure.Factory;
using Source.Infrastructure.Services;
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
        private IGameplayModeService _gameplayModeService;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, IGameFactory gameFactory,
            IGameplayModeService gameplayModeService)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _gameplayModeService = gameplayModeService;
        }

        private void Start()
        {
            var sessionConfig = InitGameWorld();

            _gameStateMachine.Enter<GameLoopState, GameSessionConfig>(sessionConfig);
        }

        private GameSessionConfig InitGameWorld()
        {
            var ship = InitShip();
            InitHUD(ship.GetComponent<IHealth>());

            return new GameSessionConfig(ship.GetComponent<IHealth>());
        }

        private GameObject InitShip() =>
            _gameFactory.CreateShip(InitialPoint.position);

        private GameObject InitHUD(IHealth playerHealth)
        {
            var hud =  _gameFactory.CreateHUD();
            hud.GetComponent<ActorUI>().Init(playerHealth);
            return hud;
        }
    }
}