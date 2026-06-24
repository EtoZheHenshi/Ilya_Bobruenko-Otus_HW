namespace Game.Code.Gameplay.Bullets.BulletEffects
{
    public abstract class BulletEffect
    {
        protected const int MaxLevel = 5;
        private int _currentLevel = 1;

        public int CurrentLevel => _currentLevel;

        public virtual void UpdateEffect()
        {
            _currentLevel++;
        }
    }
}