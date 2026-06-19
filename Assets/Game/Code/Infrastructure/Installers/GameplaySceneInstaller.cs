using Game.Code.Gameplay.Player;
using Game.Code.Gameplay.Player.PlayerSO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class GameplaySceneInstaller : MonoInstaller
    {
        [Header("SceneInitializer")]
        [SerializeField] private GameplaySceneInitializer _gameplaySceneInitializer;
        
        [Header("Types SO")] 
        [SerializeField] private PlayerTypesSO _playerTypes;
        
        public override void InstallBindings() 
        {
            BindGameplaySceneInitializer();
            BindPlayerFactory();
            BindTypesSO();

            Debug.Log($"{this.GetType()} installed");
        }

        private void BindTypesSO()
        {
            Container
                .Bind<PlayerTypesSO>()
                .FromInstance(_playerTypes)
                .AsSingle();
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