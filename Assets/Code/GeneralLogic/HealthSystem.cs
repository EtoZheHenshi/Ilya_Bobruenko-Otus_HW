using System;

namespace Code.GeneralLogic
{
    public sealed class HealthSystem : IDamageable
    {
        private readonly Stat _maxHealth;
        private float _currentHealth;
        private bool _isDead;
        
        public Stat MaxHealth => _maxHealth;
        public float CurrentHealth => _currentHealth;
        
        public event Action OnTakeDamage;
        public event Action OnDeath;

        public HealthSystem(Stat maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth.Value;
        }
        
        public void TakeDamage(float damage)
        {
            if (_isDead) return;
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

        public void Heal(float healAmount)
        {
            _currentHealth += healAmount;
            if (_currentHealth > _maxHealth.Value)
            {
                _currentHealth = _maxHealth.Value;
            }
        }
    }
}