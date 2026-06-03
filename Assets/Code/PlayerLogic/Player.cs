using Code.GeneralLogic;
using Code.Guns;
using Code.Templates;
using UnityEngine;

namespace Code.PlayerLogic
{
    [RequireComponent(
        typeof(PlayerController),
        typeof(PlayerGunSelector),
        typeof(HitFlash)
        )
    ]
    public sealed class Player : SingletonMonoBehaviour<Player>
    {
        [SerializeField] private PlayerConfigSO _playerConfig;
        
        private PlayerController _playerController;
        private PlayerGunSelector _gunSelector;
        private HitFlash _hitFlash;
        
        private HealthSystem _healthSystem;
        private PlayerLvlSystem _playerLvlSystem;
        
        private bool _isInitialized;

        protected override void OnAwake()
        {
            base.OnAwake();

            _playerController = GetComponent<PlayerController>();
            _gunSelector = GetComponent<PlayerGunSelector>();
            _hitFlash = GetComponent<HitFlash>();
            
            _healthSystem = new HealthSystem(_playerConfig.MaxHealth);
            _playerLvlSystem = new PlayerLvlSystem(_playerConfig.PlayerLvlExpTable);
            
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (!_isInitialized) return;
            
            _playerLvlSystem.UpdateTick();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IPickupable pickupable))
            {
                pickupable.Pickup(this);
            }
        }

        public void Initialize()
        {
            _playerController.Initialize();
            _gunSelector.Initialize();

            _healthSystem.OnTakeDamage += _hitFlash.Flash;
            _healthSystem.OnDeath += Death;
            
            _isInitialized = true;
        }

        public void Heal(int healAmount)
        {
            _healthSystem.Heal(healAmount);
        }

        public void AddExp(int expAmount)
        {
            _playerLvlSystem.AddExp(expAmount);
        }

        private void Death()
        {
            
        }
    }
}