using Game.Code.Gameplay.Player;
using UnityEngine;

namespace Game.Code.Gameplay.Items.ItemEffects
{
    [CreateAssetMenu(fileName = "ExpEffect", menuName = "SO/Items/Item Effects/Exp Effect")]
    public sealed class ExpEffectSO : ItemEffectSO
    {
        [SerializeField] private int _expAmount;
        
        public override void Apply(PlayerFacade playerFacade)
        {
            playerFacade.PlayerLevel.AddExp(_expAmount);
        }
    }
}