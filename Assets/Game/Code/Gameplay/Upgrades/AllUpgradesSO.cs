using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Gameplay.Upgrades
{
    [CreateAssetMenu(fileName = "AllUpgrades", menuName = "SO/Upgrades/All Upgrades")]
    public sealed class AllUpgradesSO : ScriptableObject
    {
        [SerializeField] private List<UpgradeSO> _allStatUpgradesSO;
        [SerializeField] private List<UpgradeSO> _allBulletEffectUpgradesSO;

        public List<UpgradeSO> StatUpgradesSO => _allStatUpgradesSO;
        public List<UpgradeSO> BulletEffectUpgradesSO => _allBulletEffectUpgradesSO;
    }
}