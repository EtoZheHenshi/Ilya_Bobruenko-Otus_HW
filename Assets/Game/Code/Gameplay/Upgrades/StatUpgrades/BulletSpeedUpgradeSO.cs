using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "BulletSpeedUpgrade", menuName = "SO/Upgrades/Bullet Speed Upgrade")]
    public sealed class BulletSpeedUpgradeSO : StatUpgradeSO
    {
        public override Upgrade CreateUpgrade(DiContainer container)
        {
            return container.Instantiate<BulletSpeedUpgrade>(new []{this});
        }
    }
}