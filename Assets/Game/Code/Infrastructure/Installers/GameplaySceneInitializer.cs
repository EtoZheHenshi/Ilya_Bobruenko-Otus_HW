using Game.Code.Gameplay.Enemies;
using Game.Code.Gameplay.Player;
using Game.Code.Gameplay.UI;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;
using Game.Code.Infrastructure.GameStateSystem;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class GameplaySceneInitializer : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private EnemyConfigSO _skeleton;
        private PlayerFactory _playerFactory;
        private GameStateService _gameStateService;
        private PlayerRegistry _playerRegistry;
        private EventBusService _eventBusService;
        private UiController _uiController;

        [Inject]
        public void Construct(PlayerFactory playerFactory, GameStateService gameStateService,
            PlayerRegistry playerRegistry, EventBusService eventBusService, UiController uiController)
        {
            _playerFactory = playerFactory;
            _gameStateService = gameStateService;
            _playerRegistry = playerRegistry;
            _eventBusService = eventBusService;
            _uiController = uiController;
        }
        
        public bool IsInitialized { get; private set; }
        
        public void Initialize()
        {
            GameObject player = _playerFactory.Create(0, _playerStartPosition.position);
            _playerRegistry.Register(player.GetComponent<PlayerFacade>());
            
            _uiController.Initialize();
            
            _gameStateService.SwitchGameState(GameStateType.Gameplay);

            StartCoroutine(_uiController.PlayStartWaveTimer());
            
            IsInitialized = true;

            Debug.Log($"{this.GetType()} initialized");
        }
    }
}