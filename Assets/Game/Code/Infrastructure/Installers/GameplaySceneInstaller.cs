using Game.Code.Gameplay.Bullets;
using Game.Code.Gameplay.Bullets.BulletEffects;
using Game.Code.Gameplay.Enemies;
using Game.Code.Gameplay.Enemies.SpawnerSystem;
using Game.Code.Gameplay.Enemies.WaveSystem;
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
        [SerializeField] private EnemyTypesSO _enemyTypes;
        
        [Header("Object Roots")] 
        [SerializeField] private Transform _itemsRoot;
        [SerializeField] private Transform _enemyRoot;
        [SerializeField] private Transform _bulletsRoot;
        
        [Header("Other")] 
        [SerializeField] private EnemySpawnerSystem _enemySpawnerSystem;
        [SerializeField] private AllWavesSO _allWaves;
        [SerializeField] private BulletConfigSO _bulletConfig;
        
        public override void InstallBindings() 
        {
            BindGameplaySceneInitializer();
            
            BindTypesSO();
            
            BindPlayerFactory();
            BindEnemyFactory();
            BindItemsFactory();
            BindBulletFactory();
            
            BindPlayerRegistry();

            BindBulletEffectsCollection();
            
            BindEnemySpawnerSystem();
            BindWaveSwitcher();

            Debug.Log($"{this.GetType()} installed");
        }

        private void BindBulletEffectsCollection()
        {
            Container.Bind<BulletEffectsCollection>().AsSingle();
        }

        private void BindWaveSwitcher()
        {
            Container
                .Bind<AllWavesSO>()
                .FromInstance(_allWaves)
                .AsSingle();
            
            Container
                .Bind<WaveHandler>()
                .AsSingle();
            
            Container
                .Bind<WaveSwitcher>()
                .AsSingle()
                .NonLazy();
        }

        private void BindEnemySpawnerSystem()
        {
            Container
                .Bind<EnemySpawnerSystem>()
                .FromInstance(_enemySpawnerSystem)
                .AsSingle();
        }

        private void BindPlayerRegistry()
        {
            Container
                .Bind<PlayerRegistry>()
                .AsSingle();
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
        
        private void BindEnemyFactory()
        {
            Container
                .Bind<EnemiesRoot>()
                .FromInstance(new EnemiesRoot(_enemyRoot))
                .AsSingle();
            
            Container
                .Bind<EnemyFactory>()
                .AsSingle();
        }
        
        private void BindBulletFactory()
        {
            Container
                .Bind<BulletConfigSO>()
                .FromInstance(_bulletConfig)
                .AsSingle();
            
            Container
                .Bind<BulletsRoot>()
                .FromInstance(new BulletsRoot(_bulletsRoot))
                .AsSingle();
            
            Container
                .Bind<BulletFactory>()
                .AsSingle();
        }

        private void BindTypesSO()
        {
            Container
                .Bind<PlayerTypesSO>()
                .FromInstance(_playerTypes)
                .AsSingle();
            
            Container
                .Bind<EnemyTypesSO>()
                .FromInstance(_enemyTypes)
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