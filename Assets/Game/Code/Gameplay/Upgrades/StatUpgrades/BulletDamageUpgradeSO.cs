using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "BulletDamageUpgrade", menuName = "SO/Upgrades/Stat Upgrades/Bullet Damage Upgrade")]
    public sealed class BulletDamageUpgradeSO : StatUpgradeSO
    {
        public override Upgrade CreateUpgrade(DiContainer container)
        {
            return container.Instantiate<BulletDamageUpgrade>(new []{this});
        }
    }
}