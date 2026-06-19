using Game.Code.Gameplay.Player;
using Game.Code.Infrastructure.GameStateSystem;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class GameplaySceneInitializer : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _playerStartPosition;
        private PlayerFactory _playerFactory;
        private GameStateService _gameStateService;

        [Inject]
        public void Construct(PlayerFactory playerFactory, GameStateService gameStateService)
        {
            _playerFactory = playerFactory;
            _gameStateService = gameStateService;
        }
        
        public bool IsInitialized { get; private set; }
        
        public void Initialize()
        {
            _playerFactory.Create(0, _playerStartPosition.position);
            
            _gameStateService.SwitchGameState(GameStateType.Gameplay);
            
            IsInitialized = true;

            Debug.Log($"{this.GetType()} initialized");
        }
    }
}