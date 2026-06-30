using System;
using Game.Code.Gameplay.Enemies;
using Game.Code.Gameplay.Player;
using Game.Code.Gameplay.UI;
using Game.Code.Infrastructure.Audio;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;
using Game.Code.Infrastructure.GameStateSystem;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class GameplaySceneInitializer : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private EnemyConfigSO _skeleton;
        private PlayerFactory _playerFactory;
        private GameStateService _gameStateService;
        private PlayerRegistry _playerRegistry;
        private EventBusService _eventBusService;
        private UiController _uiController;
        private AudioService _audioService;

        [Inject]
        public void Construct(PlayerFactory playerFactory, GameStateService gameStateService,
            PlayerRegistry playerRegistry, EventBusService eventBusService, UiController uiController,
            AudioService audioService)
        {
            _playerFactory = playerFactory;
            _gameStateService = gameStateService;
            _playerRegistry = playerRegistry;
            _eventBusService = eventBusService;
            _uiController = uiController;
            _audioService = audioService;
        }
        
        public bool IsInitialized { get; private set; }
        
        public void Initialize()
        {
            _audioService.SetSpawnPosition(Camera.main.transform);
            
            GameObject player = _playerFactory.Create(0, _playerStartPosition.position);
            _playerRegistry.Register(player.GetComponent<PlayerFacade>());
            
            _uiController.Initialize();
            
            _gameStateService.SwitchGameState(GameStateType.Gameplay);
            
            _audioService.PlayLoop(SoundId.GameplayTheme);

            StartCoroutine(_uiController.PlayStartWaveTimer());
            
            IsInitialized = true;

            Debug.Log($"{this.GetType()} initialized");
        }

        public void Dispose()
        {
            _audioService.StopAll();
        }
    }
}