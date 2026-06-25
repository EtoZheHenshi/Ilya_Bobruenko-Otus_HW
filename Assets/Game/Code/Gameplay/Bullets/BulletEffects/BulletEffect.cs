namespace Game.Code.Gameplay.Bullets.BulletEffects
{
    public abstract class BulletEffect
    {
        private readonly int _maxLevel;
        private int _currentLevel = 1;

        public int MaxLevel => _maxLevel;
        public int CurrentLevel => _currentLevel;

        public BulletEffect(int maxLevel)
        {
            _maxLevel = maxLevel;
        }

        public virtual void UpgradeEffect()
        {
            if (CurrentLevel < _maxLevel)
            {
                _currentLevel++;
            }
        }

        public bool CanUpgrade()
        {
            return CurrentLevel < _maxLevel;
        }
    }
}