using Source.Infrastructure;
using Source.Infrastructure.StateMachine;
using Source.Infrastructure.StateMachine.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.UI
{
    public class RestartLevelButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        private void Awake()
        {
            _button.onClick.AddListener(RestartLevel);
        }

        private void RestartLevel()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(SceneName.Main);
        }
    }
}