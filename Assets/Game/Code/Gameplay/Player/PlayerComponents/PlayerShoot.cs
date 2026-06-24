using System;
using Game.Code.Gameplay.Bullets;
using Game.Code.Gameplay.General.Stats;
using Game.Code.Infrastructure.Input;
using Game.Code.Infrastructure.UpdateSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Code.Gameplay.Player.PlayerComponents
{
    public sealed class PlayerShoot : MonoBehaviour, IUpdatable
    {
        [SerializeField] private Transform _bulletSpawnPosition;
        
        private IInputService _inputService;
        private BulletFactory _bulletFactory;
        private UpdateService _updateService;

        private Stat _fireRate;

        private float _lastShotTime;
        private bool _isShooting;
        
        public Stat FireRate => _fireRate;

        [Inject]
        public void Construct(IInputService inputService, BulletFactory bulletFactory, UpdateService updateService)
        {
            _bulletFactory = bulletFactory;
            _inputService = inputService;   
            _updateService = updateService;
            
            PlayerFacade playerFacade = GetComponent<PlayerFacade>();
            _fireRate = playerFacade.PlayerStats.FireRate;
        }
        
        public void Tick(float deltaTime)
        {
            Shoot();
        }

        private void OnEnable()
        {
            _updateService.Register(this);

            _inputService.PlayerInput.Gameplay.Shoot.started += GameplayOnShootListener;
            _inputService.PlayerInput.Gameplay.Shoot.canceled += GameplayOnShootListener;
        }

        private void OnDisable()
        {
            _updateService.Unregister(this);
            
            _inputService.PlayerInput.Gameplay.Shoot.started -= GameplayOnShootListener;
            _inputService.PlayerInput.Gameplay.Shoot.canceled -= GameplayOnShootListener;
        }

        private void Shoot()
        {
            if (_isShooting)
            {
                if (Time.time > _lastShotTime + _fireRate.CurrentValue)
                {
                    _lastShotTime = Time.time;
                    _bulletFactory.Create(_bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
                }
            }
        }

        private void GameplayOnShootListener(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
                _isShooting = true;
            
            if (ctx.canceled)
                _isShooting = false;
        }
    }
}