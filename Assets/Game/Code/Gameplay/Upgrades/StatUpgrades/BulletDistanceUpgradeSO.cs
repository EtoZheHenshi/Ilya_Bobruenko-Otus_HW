using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "BulletDistanceUpgrade", menuName = "SO/Upgrades/Stat Upgrades/Bullet Distance Upgrade")]
    public sealed class BulletDistanceUpgradeSO : StatUpgradeSO
    {
        public override Upgrade CreateUpgrade(DiContainer container)
        {
            return container.Instantiate<BulletDistanceUpgrade>(new []{this});
        }
    }
}