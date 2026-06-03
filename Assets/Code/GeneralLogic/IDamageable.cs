using System;

namespace Code.GeneralLogic
{
    public interface IDamageable
    {
        public int MaxHealth { get; }
        public int CurrentHealth { get; }
        
        public event Action OnTakeDamage;
        public event Action OnDeath;
        
        public void TakeDamage(int damage);
    }
}