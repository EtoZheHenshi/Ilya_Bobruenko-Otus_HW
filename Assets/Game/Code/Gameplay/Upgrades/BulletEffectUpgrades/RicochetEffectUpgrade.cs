using Game.Code.Gameplay.Bullets.BulletEffects;
using Game.Code.Gameplay.Bullets.BulletEffects.BulletEffectTypes;

namespace Game.Code.Gameplay.Upgrades.BulletEffectUpgrades
{
    public sealed class RicochetEffectUpgrade : BulletEffectUpgrade
    {
        private readonly RicochetEffect _ricochetEffect;
        
        public override BulletEffect BulletEffect => _ricochetEffect;

        public RicochetEffectUpgrade(BulletEffectsCollection bulletEffectsCollection,
            RicochetEffectUpgradeSO upgradeSO) : base(bulletEffectsCollection, upgradeSO)
        {
            _ricochetEffect = new RicochetEffect(upgradeSO.MaxLevel, upgradeSO.MaxRicochetAmount);
        }
    }
}