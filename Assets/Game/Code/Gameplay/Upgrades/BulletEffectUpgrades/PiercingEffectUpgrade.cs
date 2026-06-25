using Game.Code.Gameplay.Bullets.BulletEffects;
using Game.Code.Gameplay.Bullets.BulletEffects.BulletEffectTypes;

namespace Game.Code.Gameplay.Upgrades.BulletEffectUpgrades
{
    public sealed class PiercingEffectUpgrade : BulletEffectUpgrade
    {
        private readonly PiercingEffect _bulletEffect;
        
        public override BulletEffect BulletEffect => _bulletEffect;

        public PiercingEffectUpgrade(BulletEffectsCollection bulletEffectsCollection, 
            PiercingEffectUpgradeSO upgradeSO) : base(bulletEffectsCollection, upgradeSO)
        {
            _bulletEffect = new PiercingEffect(upgradeSO.MaxLevel, upgradeSO.MaxPiercingAmount);
        }
    }
}