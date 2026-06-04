using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Upgrades
{
    public sealed class UpgradeManager
    {
        private readonly List<UpgradeSO> _allUpgrades;

        public UpgradeManager(AllUpgradesSO allUpgrades)
        {
            _allUpgrades = allUpgrades.AllUpgrades;
        }

        public List<UpgradeSO> GetRandomUpgrades(int count)
        {
            List <UpgradeSO> upgrades = GetAvailableUpgrades()
                .OrderBy(_ => Random.value)
                .Take(count)
                .ToList();
            
            return upgrades;
        }

        private List<UpgradeSO> GetAvailableUpgrades()
        {
            List<UpgradeSO> availableUpgrades = _allUpgrades
                .Where(u => u.IsAvailable())
                .ToList();
            
            return availableUpgrades;
        }
    }
}