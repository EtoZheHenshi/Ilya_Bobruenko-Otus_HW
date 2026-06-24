using Game.Code.Gameplay.Bullets;
using Game.Code.Gameplay.Bullets.BulletEffects;
using Game.Code.Gameplay.Enemies;
using Game.Code.Gameplay.Enemies.SpawnerSystem;
using Game.Code.Gameplay.Enemies.WaveSystem;
using Game.Code.Gameplay.Items;
using Game.Code.Gameplay.Player;
using Game.Code.Gameplay.Player.PlayerSO;
using Game.Code.Gameplay.UI;
using Game.Code.Gameplay.UI.MiddleScreenTextWnd;
using Game.Code.Gameplay.UI.StartTimerWnd;
using Game.Code.Gameplay.UI.UpgradeMenuWnd;
using Game.Code.Gameplay.Upgrades;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class GameplaySceneInstaller : MonoInstaller
    {
        [Header("SceneInitializer")]
        [SerializeField] private GameplaySceneInitializer _gameplaySceneInitializer;
        
        [Header("Object Collections SO")] 
        [SerializeField] private PlayerTypesSO _playerTypes;
        [SerializeField] private EnemyTypesSO _enemyTypes;
        [SerializeField] private AllUpgradesSO _allUpgrades;
        
        [Header("Object Roots")] 
        [SerializeField] private Transform _itemsRoot;
        [SerializeField] private Transform _enemyRoot;
        [SerializeField] private Transform _bulletsRoot;
        
        [Header("Other")] 
        [SerializeField] private EnemySpawnerSystem _enemySpawnerSystem;
        [SerializeField] private AllWavesSO _allWaves;
        [SerializeField] private BulletConfigSO _bulletConfig;
        [SerializeField] private BulletStatsSO _bulletStats;
        
        [Header ("UI")] 
        [SerializeField] private StartTimerWndView _startTimerWndView;
        [SerializeField] private MiddleScreenTextWndView _middleScreenTextWndView;
        [SerializeField] private UpgradeMenuWndView _upgradeMenuWndView;
        
        public override void InstallBindings() 
        {
            BindGameplaySceneInitializer();
            
            BindPlayerFactory();
            BindEnemyFactory();
            BindItemsFactory();
            BindBulletFactory();
            BindUpgradeFactory();
            
            BindPlayerRegistry();

            BindBulletEffectsCollection();
            BindAllUpgrades();
            
            BindEnemySpawnerSystem();
            BindWaveSwitcher();
            BindItemDropperService();
            
            BindUiController();

            Debug.Log($"{this.GetType()} installed");
        }

        private void BindItemDropperService()
        {
            Container
                .BindInterfacesAndSelfTo<ItemDropperService>()
                .AsSingle();
        }

        private void BindAllUpgrades()
        {
            Container
                .Bind<AllUpgrades>()
                .AsSingle()
                .WithArguments(_allUpgrades)
                .NonLazy();
        }

        private void BindUpgradeFactory()
        {
            Container
                .Bind<UpgradeFactory>()
                .AsSingle();
        }

        private void BindUiController()
        {
            BindUiModels();

            Container
                .BindInterfacesAndSelfTo<UiController>()
                .AsSingle();
        }

        private void BindUiModels()
        {
            Container
                .BindInterfacesAndSelfTo<StartTimerWndModel>()
                .AsSingle()
                .WithArguments(_startTimerWndView);
            
            Container
                .Bind<MiddleScreenTextWndModel>()
                .AsSingle()
                .WithArguments(_middleScreenTextWndView);
            
            Container
                .BindInterfacesAndSelfTo<UpgradeMenuWndModel>()
                .AsSingle()
                .WithArguments(_upgradeMenuWndView)
                .NonLazy();
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
                .BindInterfacesAndSelfTo<WaveSwitcher>()
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
                .Bind<EnemyTypesSO>()
                .FromInstance(_enemyTypes)
                .AsSingle();
            
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
                .Bind<BulletStats>()
                .AsSingle()
                .WithArguments(_bulletStats);
            
            Container
                .Bind<BulletsRoot>()
                .FromInstance(new BulletsRoot(_bulletsRoot))
                .AsSingle();
            
            Container
                .Bind<BulletFactory>()
                .AsSingle();
        }

        private void BindPlayerFactory()
        {
            Container
                .Bind<PlayerTypesSO>()
                .FromInstance(_playerTypes)
                .AsSingle();
            
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