using Source.Infrastructure.StateMachine;
using Zenject;

namespace Source.Infrastructure.Zenject
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameStateMachine();
        }

        private void GameStateMachine() =>
            Container.BindInterfacesTo<GameStateMachine>();
    }
}