using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Items
{
    public sealed class ItemsFactory
    {
        private readonly DiContainer _container;

        public ItemsFactory(DiContainer container)
        {
            _container = container;
        }
        
        public void Create(Collider itemPrefab, Vector3 spawnPosition, Transform parent)
        {
            _container.InstantiatePrefab(itemPrefab, spawnPosition, Quaternion.identity, parent);
        }
    }
}