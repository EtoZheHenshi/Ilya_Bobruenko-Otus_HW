using Game.Code.Gameplay.General.Stats;
using Game.Code.Gameplay.Player;

namespace Game.Code.Gameplay.Upgrades.StatUpgrades
{
    public sealed class PlayerFireRateUpgrade : StatUpgrade
    {
        private readonly PlayerRegistry _player;

        public override Stat Stat => _player.Player.PlayerShoot.FireRate;
        
        public PlayerFireRateUpgrade(StatUpgradeSO statUpgradeSO, PlayerRegistry playerRegistry) : base(statUpgradeSO)
        {
            _player = playerRegistry;
        }

    }
}