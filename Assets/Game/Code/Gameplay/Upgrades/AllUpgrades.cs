using System.Collections.Generic;
using System.Linq;
using Game.Code.Gameplay.Player;
using UnityEngine;

namespace Game.Code.Gameplay.Upgrades
{
    public sealed class AllUpgrades
    {
        private readonly AllUpgradesSO _allUpgradesSO;
        private readonly UpgradeFactory _upgradeFactory;
        private readonly PlayerRegistry _playerRegistry;

        private readonly List<Upgrade> _statUpgrades;
        private readonly List<Upgrade> _bulletEffectUpgrades;
        
        public List<Upgrade> StatUpgrades => _statUpgrades;
        public List<Upgrade> BulletEffectUpgrades => _bulletEffectUpgrades;

        public AllUpgrades(AllUpgradesSO allUpgradesSO, UpgradeFactory upgradeFactory, PlayerRegistry playerRegistry)
        {
            _allUpgradesSO = allUpgradesSO;
            _upgradeFactory = upgradeFactory;
            _playerRegistry = playerRegistry;
            _statUpgrades = new List<Upgrade>();
            _bulletEffectUpgrades = new List<Upgrade>();
            
            LoadAllUpgrades();
        }

        public List<Upgrade> GetAvailableUpgrades(out bool haveBulletEffect)
        {
            List<Upgrade> upgrades = _statUpgrades.Where(u => u.IsAvailable()).ToList();
            haveBulletEffect = false;

            if (_playerRegistry.Player.PlayerLevel.CurrentLevel % 5 == 0)
            {
                Upgrade[] bulletUpgrades = _bulletEffectUpgrades.Where(u => u.IsAvailable()).ToArray();
                if (bulletUpgrades.Length > 0)
                {
                    upgrades.Add(bulletUpgrades[Random.Range(0, bulletUpgrades.Length)]);
                    haveBulletEffect = true;
                }
            }

            return upgrades;
        }

        private void LoadAllUpgrades()
        {
            for (int i = 0; i < _allUpgradesSO.StatUpgradesSO.Count; i++)
            {
                Upgrade upgrade = _upgradeFactory.Create(_allUpgradesSO.StatUpgradesSO[i]);
                _statUpgrades.Add(upgrade);
            }
            
            for (int i = 0; i < _allUpgradesSO.BulletEffectUpgradesSO.Count; i++)
            {
                Upgrade upgrade = _upgradeFactory.Create(_allUpgradesSO.BulletEffectUpgradesSO[i]);
                _bulletEffectUpgrades.Add(upgrade);
            }
        }
    }
}