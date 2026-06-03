using System;
using Code.PlayerLogic;
using UnityEngine;

namespace Code.Items
{
    public abstract class ItemEffectSO : ScriptableObject
    {
        public abstract void Apply(Player player); 
    }
}