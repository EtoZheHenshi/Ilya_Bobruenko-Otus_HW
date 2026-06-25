using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Upgrades.BulletEffectUpgrades
{
    [CreateAssetMenu(fileName = "RicochetUpgrade", menuName = "SO/Upgrades/Bullet Effects/Ricochet Upgrade")]
    public sealed class RicochetEffectUpgradeSO : BulletEffectUpgradeSO
    {
        [SerializeField] private int _maxRicochetAmount;
        
        public int MaxRicochetAmount => _maxRicochetAmount;
        
        public override Upgrade CreateUpgrade(DiContainer container)
        {
            return container.Instantiate<RicochetEffectUpgrade>(new [] { this });
        }
    }
}