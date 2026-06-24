using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Upgrades.StatUpgrades
{
    [CreateAssetMenu(fileName = "PlayerHealthUpgrade", menuName = "SO/Upgrades/Player Health Upgrade")]
    public sealed class PlayerHealthUpgradeSO : StatUpgradeSO
    {
        public override Upgrade CreateUpgrade(DiContainer container)
        {
            return container.Instantiate<PlayerHealthUpgrade>(new []{this});
        }
    }
}