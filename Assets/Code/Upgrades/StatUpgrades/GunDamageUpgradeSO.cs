using Code.GeneralLogic;
using Code.Guns;
using UnityEngine;

namespace Code.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "GunDamageUpgrade", menuName = "Upgrades/Stat Upgrades/Gun Damage Upgrade")]
    public sealed class GunDamageUpgradeSO : StatUpgradeSO
    {
        [SerializeField] private GunStatsSO _gunStats;

        public override Stat Stat => _gunStats.Damage;
    }
}