namespace Source.Infrastructure.StateMachine.States
{
    public class EndGameSessionState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly GameOverScreen _gameOverScreen;

        public EndGameSessionState(IGameStateMachine gameStateMachine, GameOverScreen gameOverScreen)
        {
            _gameStateMachine = gameStateMachine;
            _gameOverScreen = gameOverScreen;
        }

        public void Enter()
        {
            _gameOverScreen.Show();
        }

        public void Exit() =>
            _gameOverScreen.Hide();
    }
}