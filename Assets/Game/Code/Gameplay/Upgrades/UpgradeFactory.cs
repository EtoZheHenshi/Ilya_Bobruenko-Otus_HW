using Zenject;

namespace Game.Code.Gameplay.Upgrades
{
    public sealed class UpgradeFactory
    {
        private readonly DiContainer _container;

        public UpgradeFactory(DiContainer container)
        {
            _container = container;
        }

        public Upgrade Create(UpgradeSO upgradeSO)
        {
            return upgradeSO.CreateUpgrade(_container);
        }
    }
}