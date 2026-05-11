using System;
using UnityEngine;

namespace Code.Enemies
{
    public sealed class EnemyHealthSystem : MonoBehaviour, IDamageable
    {
        private int _maxHealth;
        private int _currentHealth;
        
        public int MaxHealth => _maxHealth;
        public int CurrentHealth => _currentHealth;
        
        public event Action OnTakeDamage;
        public event Action OnDeath;

        public void Initialize(int maxHealth)
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
    }
}