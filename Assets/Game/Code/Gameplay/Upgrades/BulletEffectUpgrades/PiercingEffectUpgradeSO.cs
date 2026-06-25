using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Upgrades.BulletEffectUpgrades
{
    [CreateAssetMenu(fileName = "PiercingUpgrade", menuName = "SO/Upgrades/Bullet Effects/Piercing Upgrade")]
    public sealed class PiercingEffectUpgradeSO : BulletEffectUpgradeSO
    {
        [SerializeField] private int _maxPiercingAmount;
        
        public int MaxPiercingAmount => _maxPiercingAmount;

        public override Upgrade CreateUpgrade(DiContainer container)
        {
            return container.Instantiate<PiercingEffectUpgrade>(new object[] { this });
        }
    }
}