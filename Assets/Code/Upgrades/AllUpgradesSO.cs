using System.Collections.Generic;
using UnityEngine;

namespace Code.Upgrades
{
    [CreateAssetMenu(fileName = "AllUpgrades", menuName = "Upgrades/All Upgrades")]
    public sealed class AllUpgradesSO : ScriptableObject
    {
        [SerializeField] private List<UpgradeSO> _allUpgrades;
        
        public List<UpgradeSO> AllUpgrades => _allUpgrades;
    }
}