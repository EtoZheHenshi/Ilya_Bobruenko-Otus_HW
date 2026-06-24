using Game.Code.Gameplay.Bullets;
using Game.Code.Gameplay.General.Stats;

namespace Game.Code.Gameplay.Upgrades.StatUpgrades
{
    public sealed class BulletDistanceUpgrade : StatUpgrade
    {
        private readonly BulletStats _bulletStats;

        public override Stat Stat => _bulletStats.Distance;

        public BulletDistanceUpgrade(StatUpgradeSO statUpgradeSO, BulletStats bulletStats) : base(statUpgradeSO)
        {
            _bulletStats = bulletStats;
        }
    }
}