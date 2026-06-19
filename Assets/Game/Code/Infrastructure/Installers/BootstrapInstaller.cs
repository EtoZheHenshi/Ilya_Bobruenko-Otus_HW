using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.Input;
using Game.Code.Infrastructure.UpdateSystem;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class BootstrapInstaller :MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindUpdateService();
            BindEventBusService();
            BindBootstrapInitializer();

            Debug.Log($"{this.GetType()} installed");
        }

        private void BindBootstrapInitializer()
        {
            Container
                .BindInterfacesAndSelfTo<BootstrapInitializer>()
                .AsSingle()
                .NonLazy();
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
                .BindInterfacesAndSelfTo<UpdateService>()
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