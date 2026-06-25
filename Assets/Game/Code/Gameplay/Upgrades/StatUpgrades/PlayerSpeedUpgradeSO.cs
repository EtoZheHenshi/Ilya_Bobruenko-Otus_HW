using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "PlayerSpeedUpgrade", menuName = "SO/Upgrades/Stat Upgrades/Player Speed Upgrade")]
    public sealed class PlayerSpeedUpgradeSO : StatUpgradeSO 
    {
        public override Upgrade CreateUpgrade(DiContainer container)
        {
            return container.Instantiate<PlayerSpeedUpgrade>(new []{this});
        }
    }
}