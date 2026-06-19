using Game.Code.Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class GameplaySceneInitializer : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _playerStartPosition;
        private PlayerFactory _playerFactory;

        [Inject]
        public void Construct(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        
        public bool IsInitialized { get; private set; }
        
        public void Initialize()
        {
            _playerFactory.Create(0, _playerStartPosition.position);
            
            IsInitialized = true;

            Debug.Log($"{this.GetType()} initialized");
        }
    }
}