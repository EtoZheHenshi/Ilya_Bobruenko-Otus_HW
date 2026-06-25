using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Upgrades.BulletEffectUpgrades
{
    [CreateAssetMenu(fileName = "DuplicateUpgrade", menuName = "SO/Upgrades/Bullet Effects/Duplicate Upgrade")]
    public sealed class DuplicateEffectUpgradeSO : BulletEffectUpgradeSO
    {
        [SerializeField] private int _maxDuplicateAmount;
        
        public int MaxDuplicateAmount => _maxDuplicateAmount;
        
        public override Upgrade CreateUpgrade(DiContainer container)
        {
            return container.Instantiate<DuplicateEffectUpgrade>(new[] { this });
        }
    }
}