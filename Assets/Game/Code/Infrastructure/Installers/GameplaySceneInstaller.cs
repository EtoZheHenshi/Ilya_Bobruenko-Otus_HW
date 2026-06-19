using Game.Code.Gameplay.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private GameplaySceneInitializer _gameplaySceneInitializer;
        
        public override void InstallBindings() 
        {
            if (BootstrapInitializer.CheckBootstrapStatus(SceneManager.GetActiveScene()) == false)
            {
                return;
            }

            BindGameplaySceneInitializer();
            BindPlayerFactory();

            Debug.Log($"{this.GetType()} installed");
        }

        private void BindPlayerFactory()
        {
            Container
                .Bind<PlayerFactory>()
                .AsSingle();
        }

        private void BindGameplaySceneInitializer()
        {
            Container
                .BindInterfacesAndSelfTo<GameplaySceneInitializer>()
                .FromInstance(_gameplaySceneInitializer)
                .AsSingle()
                .NonLazy();
        }
    }
}