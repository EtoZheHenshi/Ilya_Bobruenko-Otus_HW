using Game.Code.Gameplay.General.Stats;
using Game.Code.Gameplay.Player;
using UnityEngine;

namespace Game.Code.Gameplay.Upgrades.StatUpgrades
{
    public sealed class PlayerHealthUpgrade : StatUpgrade
    {
        private readonly PlayerRegistry _player;

        public override Stat Stat => _player.Player.PlayerHealth.MaxHealth;

        public PlayerHealthUpgrade(StatUpgradeSO statUpgradeSO, PlayerRegistry playerRegistry) : base(statUpgradeSO)
        {
            _player = playerRegistry;
        }

        public override void Apply()
        {
            base.Apply();
            _player.Player.PlayerHealth.Heal(StatModifier.Value);
        }
    }
}