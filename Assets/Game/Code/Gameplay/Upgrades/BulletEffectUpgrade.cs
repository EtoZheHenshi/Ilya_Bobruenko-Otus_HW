using Game.Code.Gameplay.Bullets.BulletEffects;

namespace Game.Code.Gameplay.Upgrades
{
    public abstract class BulletEffectUpgrade : Upgrade
    {
        private readonly BulletEffectsCollection _bulletEffectsCollection;
        
        public abstract BulletEffect BulletEffect { get; }
        
        protected BulletEffectUpgrade(BulletEffectsCollection bulletEffectsCollection,
            BulletEffectUpgradeSO upgradeSO) : base(upgradeSO)
        {
            _bulletEffectsCollection = bulletEffectsCollection;
        }

        public override void Apply()
        {
            if (_bulletEffectsCollection.Contains(BulletEffect))
            {
                BulletEffect.UpgradeEffect();
            }
            else
            {
                _bulletEffectsCollection.Add(BulletEffect);
            }
        }

        public override bool IsAvailable()
        {
            return BulletEffect.CanUpgrade();
        }
    }
}