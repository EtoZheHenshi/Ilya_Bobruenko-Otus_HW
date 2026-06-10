using Code.GeneralLogic;
using Code.Guns;
using UnityEngine;

namespace Code.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "GunFireRateUpgrade", menuName = "Upgrades/Stat Upgrades/Gun Fire Rate Upgrade")]
    public sealed class GunFireRateUpgradeSO : StatUpgradeSO
    {
        [SerializeField] private GunStatsSO _gunStats;

        public override Stat Stat => _gunStats.FireRate;
    }
}