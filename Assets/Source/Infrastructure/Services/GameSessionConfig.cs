using Source.GameLogic.Ship;

namespace Source.Infrastructure.Services
{
    public class GameSessionConfig
    {
        public IHealth Player { get; private set; }

        public GameSessionConfig(IHealth player)
        {
            Player = player;
        }
    }
}