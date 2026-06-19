using System;
using UnityEngine;

namespace Game.Code.Gameplay.Items
{
    [CreateAssetMenu(fileName = "DroppableItems", menuName = "SO/Items/DroppableItems")]
    public sealed class DroppableItemsSO : ScriptableObject
    {
        [SerializeField] private DroppableItem[] _droppableItems;
        
        public DroppableItem[] DroppableItems => _droppableItems;
    }

    [Serializable]
    public sealed class DroppableItem
    {
        public ItemConfigSO Config;
        public int Amount;
        public float DropRate;
    }
}