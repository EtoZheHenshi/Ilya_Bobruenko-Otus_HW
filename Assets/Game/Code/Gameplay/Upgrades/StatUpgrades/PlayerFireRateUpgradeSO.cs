using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "PlayerFireRateUpgrade", menuName = "SO/Upgrades/Stat Upgrades/Player Fire Rate Upgrade")]
    public sealed class PlayerFireRateUpgradeSO : StatUpgradeSO
    {
        public override Upgrade CreateUpgrade(DiContainer container)
        {
            return container.Instantiate<PlayerFireRateUpgrade>( new []{this});
        }
    }
}