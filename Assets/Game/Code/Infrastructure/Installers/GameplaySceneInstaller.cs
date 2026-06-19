using Game.Code.Gameplay.Items;
using Game.Code.Gameplay.Player;
using Game.Code.Gameplay.Player.PlayerSO;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class GameplaySceneInstaller : MonoInstaller
    {
        [Header("SceneInitializer")]
        [SerializeField] private GameplaySceneInitializer _gameplaySceneInitializer;
        
        [Header("Types SO")] 
        [SerializeField] private PlayerTypesSO _playerTypes;
        
        [Header("Object Roots")] 
        [SerializeField] private Transform _itemsRoot;
        
        public override void InstallBindings() 
        {
            BindGameplaySceneInitializer();
            BindPlayerFactory();
            BindTypesSO();
            BindItemsFactory();

            Debug.Log($"{this.GetType()} installed");
        }

        private void BindItemsFactory()
        {
            Container
                .Bind<ItemsRoot>()
                .FromInstance(new ItemsRoot(_itemsRoot))
                .AsSingle();
            
            Container
                .Bind<ItemsFactory>()
                .AsSingle();
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