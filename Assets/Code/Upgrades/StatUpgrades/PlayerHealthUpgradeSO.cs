using System;
using Code.GeneralLogic;
using Code.PlayerLogic;
using UnityEngine;

namespace Code.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "PlayerHealthUpgrade", menuName = "Upgrades/Stat Upgrades/Player Health Upgrade")]
    public sealed class PlayerHealthUpgradeSO : StatUpgradeSO
    {
        [SerializeField] private PlayerStatsSO _playerStats;
        
        public override Stat Stat => _playerStats.MaxHealth;
    }
}