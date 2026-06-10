using System;
using System.Collections;
using Code.GeneralLogic;
using Code.Items;
using Code.PlayerLogic;
using UnityEngine;

namespace Code.Enemies
{
    [RequireComponent(
        typeof(HitFlash), 
        typeof(EnemyController)
        )
    ]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyConfigSO _config;
        
        private HitFlash _hitFlash;
        private EnemyController _controller;
        
        private HealthSystem _healthSystem;
        private DropSystem _dropSystem;
        
        private bool _canTouchHit = true;
        
        public HealthSystem HealthSystem => _healthSystem;
        
        private void Awake()
        {
            _hitFlash = GetComponent<HitFlash>();
            _controller = GetComponent<EnemyController>();
            
            _healthSystem = new HealthSystem(_config.Stats.MaxHealth);
            _dropSystem = new DropSystem(_config.DroppableItems.DroppableItems, transform);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                StartCoroutine(TouchHit(player.TakeDamage));
            }
        }

        public void Initialize()
        {
            _healthSystem.OnTakeDamage += _hitFlash.Flash;
            _healthSystem.OnDeath += _dropSystem.CreateDrop;
            _healthSystem.OnDeath += AddKilledEnemies;
            _healthSystem.OnDeath += Death;
            
            _controller.Initialize(Player.Instance.transform, _config.Stats.MoveSpeed);
        }

        public void TakeDamage(int damage)
        {
            _healthSystem.TakeDamage(damage);
        }

        protected virtual IEnumerator TouchHit(Action<float> takeDamageMethod)
        {
            if (_canTouchHit)
            {
                _canTouchHit = false;
                takeDamageMethod(_config.Stats.TouchDamage.Value);
                yield return new WaitForSeconds(_config.Stats.TouchDamageDelay);
                _canTouchHit = true;
            }
        }

        protected virtual void Death()
        {
            Destroy(gameObject);
        }

        private void AddKilledEnemies()
        {
            Player.Instance.KilledEnemies++;
        }
    }
}