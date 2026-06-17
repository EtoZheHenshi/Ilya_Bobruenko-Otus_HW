using Game.Code.Infrastructure.Input;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class BootstrapInstaller :MonoInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();
            
            Container.Bind<IInputService>().To<InputService>().AsSingle();
        }
    }
}