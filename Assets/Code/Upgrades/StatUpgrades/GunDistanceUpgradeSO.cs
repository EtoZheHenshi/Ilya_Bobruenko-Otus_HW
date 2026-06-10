using Code.GeneralLogic;
using Code.Guns;
using UnityEngine;

namespace Code.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "GunDistanceUpgrade", menuName = "Upgrades/Stat Upgrades/Gun Distance Upgrade")]
    public sealed class GunDistanceUpgradeSO : StatUpgradeSO
    {
        [SerializeField] private GunStatsSO _gunStats;

        public override Stat Stat => _gunStats.Distance;
    }
}