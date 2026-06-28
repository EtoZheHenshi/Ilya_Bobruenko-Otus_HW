using Game.Code.Infrastructure.Audio;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.GameStateSystem;
using Game.Code.Infrastructure.Input;
using Game.Code.Infrastructure.UpdateSystem;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class BootstrapInstaller :MonoInstaller
    {
        [SerializeField] private AudioService _audioService;
        
        public override void InstallBindings()
        {
            BindBootstrapInitializer();
            
            BindInputService();
            BindUpdateService();
            BindEventBusService();
            BindGameStateService();
            BindCoroutineRunner();
            BindAudioService();

            Debug.Log($"{this.GetType()} installed");
        }

        private void BindAudioService()
        {
            Container
                .BindInterfacesAndSelfTo<AudioService>()
                .FromComponentInNewPrefab(_audioService)
                .WithGameObjectName("[AudioService]")
                .AsSingle()
                .NonLazy();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName("[CoroutineRunner]")
                .AsSingle()
                .NonLazy();
        }

        private void BindGameStateService()
        {
            Container
                .Bind<GameStateService>()
                .AsSingle();
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