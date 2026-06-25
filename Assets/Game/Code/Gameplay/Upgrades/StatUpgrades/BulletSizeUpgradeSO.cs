using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "BulletSizeUpgrade", menuName = "SO/Upgrades/Stat Upgrades/Bullet Size Upgrade")]
    public sealed class BulletSizeUpgradeSO : StatUpgradeSO
    {
        public override Upgrade CreateUpgrade(DiContainer container)
        {
            return container.Instantiate<BulletSizeUpgrade>(new []{this});
        }
    }
}