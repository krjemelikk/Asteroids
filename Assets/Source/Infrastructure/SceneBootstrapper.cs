using System.Threading.Tasks;
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

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }

        private async Task Start()
        {
            var sessionConfig = await InitGameWorld();

            _gameStateMachine.Enter<GameLoopState, GameSessionConfig>(sessionConfig);
        }

        private async Task<GameSessionConfig> InitGameWorld()
        {
            var ship = await InitShip();
            await InitHUD(ship.GetComponent<IHealth>());

            return new GameSessionConfig(ship.GetComponent<IHealth>());
        }

        private async Task<GameObject> InitShip() =>
            await _gameFactory.CreateShip(InitialPoint.position);

        private async Task<GameObject> InitHUD(IHealth playerHealth)
        {
            var hud = await _gameFactory.CreateHUD();
            hud.GetComponent<ActorUI>().Init(playerHealth);
            return hud;
        }
    }
}