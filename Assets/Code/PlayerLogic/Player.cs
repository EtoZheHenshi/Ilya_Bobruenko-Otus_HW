using System;
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

        public float CurrentHP => _healthSystem.CurrentHealth;
        public int CurrentLvl => _playerLvlSystem.CurrentLvl;
        
        public event Action OnLvlUp
        {
            add => _playerLvlSystem.OnLvlUp += value;
            remove => _playerLvlSystem.OnLvlUp -= value;
        }
        
        public event Action OnHeal
        {
            add => _healthSystem.OnHeal += value;
            remove => _healthSystem.OnHeal -= value;
        }
        
        public event Action OnTakeDamage
        {
            add => _healthSystem.OnTakeDamage += value;
            remove => _healthSystem.OnTakeDamage -= value;
        }
        
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
            
            _healthSystem = new HealthSystem(_playerConfig.Stats.MaxHealth);
            _playerLvlSystem = new PlayerLvlSystem(_playerConfig.LvlExpTable);
            
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
            _playerController.Initialize(_playerConfig.Stats.MoveSpeed);
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

        public void TakeDamage(float damageAmount)
        {
            _healthSystem.TakeDamage(damageAmount);
        }

        private void Death()
        {
            Debug.Log("Death");
        }
    }
}