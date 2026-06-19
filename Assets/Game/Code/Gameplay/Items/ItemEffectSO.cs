using Game.Code.Gameplay.Player;
using UnityEngine;

namespace Game.Code.Gameplay.Items
{
    public abstract class ItemEffectSO : ScriptableObject
    {
        public abstract void Apply(PlayerFacade playerFacade);
    }
}