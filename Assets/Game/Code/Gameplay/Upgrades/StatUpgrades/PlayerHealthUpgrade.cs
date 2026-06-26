using Game.Code.Gameplay.General.Stats;
using Game.Code.Gameplay.Player;
using Game.Code.Gameplay.UI.HUD.HP;
using UnityEngine;

namespace Game.Code.Gameplay.Upgrades.StatUpgrades
{
    public sealed class PlayerHealthUpgrade : StatUpgrade
    {
        private readonly PlayerRegistry _player;
        private readonly HpGroupModel _hpGroupModel;

        public override Stat Stat => _player.Player.PlayerHealth.MaxHealth;

        public PlayerHealthUpgrade(StatUpgradeSO statUpgradeSO, PlayerRegistry playerRegistry,
            HpGroupModel hpGroupModel) : base(statUpgradeSO)
        {
            _player = playerRegistry;
            _hpGroupModel = hpGroupModel;
        }

        public override void Apply()
        {
            base.Apply();
            _player.Player.PlayerHealth.Heal(StatModifier.Value);
            _hpGroupModel.AddHpIcon((int)_player.Damageable.MaxHealth.CurrentValue - 1);
        }
    }
}