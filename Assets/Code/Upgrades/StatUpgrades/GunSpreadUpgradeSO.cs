using Code.GeneralLogic;
using Code.Guns;
using UnityEngine;

namespace Code.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "GunSpreadUpgrade", menuName = "Upgrades/Stat Upgrades/Gun Spread Upgrade")]
    public sealed class GunSpreadUpgradeSO : StatUpgradeSO
    {
        [SerializeField] private GunStatsSO _gunStats;

        public override Stat Stat => _gunStats.Spread;
    }
}