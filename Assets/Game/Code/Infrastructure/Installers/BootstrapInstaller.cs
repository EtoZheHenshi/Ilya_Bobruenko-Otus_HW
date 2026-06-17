using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.Input;
using Game.Code.Infrastructure.UpdateSystem;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class BootstrapInstaller :MonoInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();

            BindInputService();
            BindUpdateService();
            BindEventBusService();
        }

        private void BindEventBusService()
        {
            Container
                .Bind<EventBusService>()
                .AsSingle();
        }

        private void BindUpdateService()
        {
            Container
                .Bind<UpdateService>()
                .AsSingle();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .To<InputService>()
                .AsSingle();
        }
    }
}