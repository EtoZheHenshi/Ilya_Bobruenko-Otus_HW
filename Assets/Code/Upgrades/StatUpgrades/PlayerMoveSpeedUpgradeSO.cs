using System;
using Code.GeneralLogic;
using Code.PlayerLogic;
using UnityEngine;

namespace Code.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "PlayerMoveSpeedUpgrade", menuName = "Upgrades/Stat Upgrades/Player Move Speed Upgrade")]
    public class PlayerMoveSpeedUpgradeSO : StatUpgradeSO
    {
        [SerializeField] private PlayerStatsSO _playerStats;

        public override Stat Stat => _playerStats.MoveSpeed;
    }
}