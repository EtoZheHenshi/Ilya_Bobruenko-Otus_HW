using System.Collections.Generic;
using System.Linq;

namespace Game.Code.Gameplay.Upgrades
{
    public sealed class AllUpgrades
    {
        private readonly AllUpgradesSO _allUpgradesSO;
        private readonly UpgradeFactory _upgradeFactory;
        
        private List<Upgrade> _upgrades;
        
        public List<Upgrade> Upgrades => _upgrades;

        public AllUpgrades(AllUpgradesSO allUpgradesSO, UpgradeFactory upgradeFactory)
        {
            _allUpgradesSO = allUpgradesSO;
            _upgradeFactory = upgradeFactory;
            _upgrades = new List<Upgrade>();
            
            LoadAllUpgrades();
        }

        public List<Upgrade> GetAvailableUpgrades()
        {
            return _upgrades.Where(u => u.IsAvailable()).ToList();
        }

        private void LoadAllUpgrades()
        {
            for (int i = 0; i < _allUpgradesSO.UpgradesSO.Count; i++)
            {
                Upgrade upgrade = _upgradeFactory.Create(_allUpgradesSO.UpgradesSO[i]);
                _upgrades.Add(upgrade);
            }
        }
    }
}