using System;
using System.Collections;
using Game.Code.Gameplay.General;
using Game.Code.Gameplay.General.Stats;
using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Player.PlayerComponents
{
    [RequireComponent(typeof(HitFlash))]
    public sealed class PlayerHealth : MonoBehaviour, IDamageable
    {
        private const float InvincibleDuration = 1f;
        
        public event Action OnTakeDamage;
        public event Action OnDeath;
        public event Action OnHeal;
        
        public Stat MaxHealth => _maxHealth;
        public float CurrentHealth => _currentHealth;

        private Stat _maxHealth;
        private float _currentHealth;
        private bool _isDead;
        private HitFlash _hitFlash;
        private bool _isInvincible;

        [Inject]
        public void Construct()
        {
            PlayerFacade playerFacade = GetComponent<PlayerFacade>();
            _maxHealth = new Stat(playerFacade.PlayerStats.MaxHealth);
            _currentHealth = _maxHealth.CurrentValue;
            _hitFlash = GetComponent<HitFlash>();
        }

        public void TakeDamage(float damage)
        {
            if (_isInvincible || _isDead) return;
            
            StartCoroutine(InvincibleTime());
            
            _hitFlash.Flash();
            
            _currentHealth -= damage;
            Debug.Log($"HP : {_currentHealth}");

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
        
        public void Heal(float healAmount)
        {
            _currentHealth += healAmount;
            if (_currentHealth > _maxHealth.CurrentValue)
            {
                _currentHealth = _maxHealth.CurrentValue;
            }
            OnHeal?.Invoke();
        }

        private IEnumerator InvincibleTime()
        {
            _isInvincible = true;
            yield return new WaitForSeconds(InvincibleDuration);
            _isInvincible = false;
        }
    }
}