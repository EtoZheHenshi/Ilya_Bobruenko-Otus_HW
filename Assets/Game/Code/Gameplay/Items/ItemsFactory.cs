using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Items
{
    public sealed class ItemsFactory
    {
        private readonly DiContainer _container;
        private readonly ItemsRoot _itemsRoot;

        public ItemsFactory(DiContainer container, ItemsRoot itemsRoot)
        {
            _container = container;
            _itemsRoot = itemsRoot;
        }
        
        public void Create(ItemPickup itemPrefab, Vector3 spawnPosition)
        {
            _container.InstantiatePrefab(itemPrefab, spawnPosition, Quaternion.identity, _itemsRoot.Transform);
        }
    }
}