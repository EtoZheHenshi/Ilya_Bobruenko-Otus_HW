using System;
using Code.Enemies;
using UnityEngine;

namespace Code.GeneralLogic
{
    public sealed class HealthSystem : IDamageable
    {
        private int _maxHealth;
        private int _currentHealth;
        
        public int MaxHealth => _maxHealth;
        public int CurrentHealth => _currentHealth;
        
        public event Action OnTakeDamage;
        public event Action OnDeath;

        public HealthSystem(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }
        
        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth > 0)
            {
                OnTakeDamage?.Invoke();
            }
            else
            {
                OnDeath?.Invoke();
            }
        }

        public void Heal(int healAmount)
        {
            _currentHealth += healAmount;
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}