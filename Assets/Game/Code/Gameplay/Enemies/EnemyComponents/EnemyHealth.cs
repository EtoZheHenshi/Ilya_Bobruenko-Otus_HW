using System;
using Game.Code.Gameplay.General;
using Game.Code.Gameplay.General.Stats;
using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Enemies.EnemyComponents
{
    [RequireComponent(typeof(HitFlash))]
    public sealed class EnemyHealth : MonoBehaviour, IDamageable
    {
        public event Action OnTakeDamage;
        public event Action OnDeath;

        private EnemyFacade _enemyFacade;
        private HitFlash _hitFlash;
        
        private Stat _maxHealth;
        private float _currentHealth;
        private bool _isDead;
        
        public Stat MaxHealth => _maxHealth;
        public float CurrentHealth => _currentHealth;

        [Inject]
        public void Construct()
        {
            _enemyFacade = GetComponent<EnemyFacade>();
            _maxHealth = new Stat(_enemyFacade.Stats.MaxHealth);
            _currentHealth = _maxHealth.CurrentValue;
            _hitFlash = GetComponent<HitFlash>();
        }
        
        public void TakeDamage(float damage)
        {
            if (_isDead) return;
            
            _hitFlash.Flash();
            
            _currentHealth -= damage;

            if (_currentHealth > 0)
            {
                OnTakeDamage?.Invoke();
            }
            else
            {
                _isDead = true;
                OnDeath?.Invoke();
            }
        }
    }
}