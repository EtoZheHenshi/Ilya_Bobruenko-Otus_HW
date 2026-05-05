namespace Code.Enemies
{
    public interface IDamageable
    {
        public int MaxHealth { get; }
        public int CurrentHealth { get; }
        
        public void TakeDamage(int damage);
    }
}