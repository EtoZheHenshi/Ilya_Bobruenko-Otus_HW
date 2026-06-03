using System;

namespace Code.GeneralLogic
{
    public interface IDamageable
    {
        public Stat MaxHealth { get; }
        public float CurrentHealth { get; }
        
        public event Action OnTakeDamage;
        public event Action OnDeath;
        
        public void TakeDamage(float damage);
    }
}