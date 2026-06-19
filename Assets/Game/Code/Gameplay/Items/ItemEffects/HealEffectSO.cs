using Game.Code.Gameplay.Player;
using UnityEngine;

namespace Game.Code.Gameplay.Items.ItemEffects
{
    [CreateAssetMenu(fileName = "HealEffect", menuName = "SO/Items/Item Effects/Heal Effect")]
    public sealed class HealEffectSO : ItemEffectSO
    {
        [SerializeField] private int _healAmount;
        
        public override void Apply(PlayerFacade playerFacade)
        {
            playerFacade.PlayerHealth.Heal(_healAmount);
        }
    }
}