using Game.Code.Gameplay.Bullets;
using Game.Code.Gameplay.Bullets.BulletEffects;
using Game.Code.Gameplay.Bullets.BulletEffects.BulletEffectTypes;

namespace Game.Code.Gameplay.Upgrades.BulletEffectUpgrades
{
    public sealed class DuplicateEffectUpgrade : BulletEffectUpgrade
    {
        private readonly DuplicateEffect _duplicateEffect;
        
        public override BulletEffect BulletEffect => _duplicateEffect;

        public DuplicateEffectUpgrade(BulletEffectsCollection bulletEffectsCollection, 
            DuplicateEffectUpgradeSO upgradeSO, BulletFactory bulletFactory) : base(bulletEffectsCollection, upgradeSO)
        {
            _duplicateEffect = new DuplicateEffect(upgradeSO.MaxLevel, upgradeSO.MaxDuplicateAmount, bulletFactory);
        }
    }
}