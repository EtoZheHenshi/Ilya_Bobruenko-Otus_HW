using System;
using UnityEngine;

namespace Code.Enemies
{
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth;
        
        private int _currentHealth;
        
        public int MaxHealth => maxHealth;
        public int CurrentHealth => _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                Debug.Log("Die");
            }
        }
    }
}