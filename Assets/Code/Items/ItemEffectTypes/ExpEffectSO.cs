using Code.PlayerLogic;
using UnityEngine;

namespace Code.Items.ItemEffectTypes
{
    [CreateAssetMenu(fileName = "ExpEffect", menuName = "Items/ItemEffects/ExpEffect")]
    public sealed class ExpEffectSO : ItemEffectSO
    {
        [SerializeField] private int _expAmount;
        
        public override void Apply(Player player)
        {
            player.AddExp(_expAmount);
        }
    }
}