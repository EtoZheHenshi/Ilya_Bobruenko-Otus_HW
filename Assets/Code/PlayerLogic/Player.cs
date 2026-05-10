using Code.Guns;
using Code.Templates;
using UnityEngine;

namespace Code.PlayerLogic
{
    [RequireComponent(
        typeof(PlayerController),
        typeof(PlayerGunSelector)
        )
    ]
    public sealed class Player : SingletonMonoBehaviour<Player>
    {
        private PlayerController _playerController;
        private PlayerGunSelector _gunSelector;

        protected override void OnAwake()
        {
            base.OnAwake();
            
            _playerController = GetComponent<PlayerController>();
            _gunSelector = GetComponent<PlayerGunSelector>();
            
            DontDestroyOnLoad(this);
        }

        public void Initialize()
        {
            _playerController.Initialize();
            _gunSelector.Initialize();
        }
    }
}