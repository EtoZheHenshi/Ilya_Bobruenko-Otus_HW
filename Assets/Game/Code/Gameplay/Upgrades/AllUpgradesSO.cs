using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Gameplay.Upgrades
{
    [CreateAssetMenu(fileName = "AllUpgrades", menuName = "SO/Upgrades/All Upgrades")]
    public sealed class AllUpgradesSO : ScriptableObject
    {
        [SerializeField] private List<UpgradeSO> _allUpgradesSO;

        public List<UpgradeSO> UpgradesSO => _allUpgradesSO;
    }
}