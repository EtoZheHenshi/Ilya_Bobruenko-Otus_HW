using System;
using UnityEngine;

namespace Code.Items
{
    [CreateAssetMenu (fileName = "DroppableItems", menuName = "Items/DroppableItems")]
    public sealed class DroppableItemsSO : ScriptableObject
    {
        [SerializeField] private DroppableItem[] _droppableItems;
        
        public DroppableItem[] DroppableItems => _droppableItems;
    }

    [Serializable]
    public sealed class DroppableItem
    {
        [SerializeField] private ItemConfig _config;
        [SerializeField] private int _count;
        [SerializeField] private float _dropRate;
        
        public ItemConfig Config => _config;
        public int Count => _count;
        public float DropRate => _dropRate;
    }
}