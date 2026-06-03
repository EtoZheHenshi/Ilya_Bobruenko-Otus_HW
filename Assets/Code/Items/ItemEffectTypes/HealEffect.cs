using Code.PlayerLogic;
using UnityEngine;

namespace Code.Items.ItemEffectTypes
{
    [CreateAssetMenu(fileName = "HealEffect", menuName = "Items/ItemEffects/HealEffect")]
    public sealed class HealEffect : ItemEffect
    {
        [SerializeField] private int _healAmount;
        
        public override void Apply(Player player)
        {
            player.Heal(_healAmount);
        }
    }
}