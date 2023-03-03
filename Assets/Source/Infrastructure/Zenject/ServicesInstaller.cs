using Source.Infrastructure.StateMachine;
using Source.Infrastructure.StateMachine.States.Factory;
using Zenject;

namespace Source.Infrastructure.Zenject
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameStateMachine();

            StatesFactory();
        }

        private void GameStateMachine() =>
            Container.BindInterfacesTo<GameStateMachine>().AsSingle();

        private void StatesFactory() =>
            Container.BindInterfacesTo<StatesFactory>().AsSingle();
    }
}