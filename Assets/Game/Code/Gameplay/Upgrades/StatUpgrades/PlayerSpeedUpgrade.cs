using Game.Code.Gameplay.General.Stats;
using Game.Code.Gameplay.Player;
using UnityEngine;

namespace Game.Code.Gameplay.Upgrades.StatUpgrades
{
    public sealed class PlayerSpeedUpgrade : StatUpgrade
    {
        private readonly PlayerRegistry _player;

        public override Stat Stat => _player.Player.PlayerMove.MoveSpeed;

        public PlayerSpeedUpgrade(StatUpgradeSO statUpgradeSO, PlayerRegistry playerRegistry) : base(statUpgradeSO)
        {
            _player = playerRegistry;
        }
    }
}