using System;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Code.Gameplay.Items
{
    public sealed class ItemDropperService : IDisposable
    { 
        private const float SpawnPositionOffset = 1f;
        
        private readonly ItemsFactory _itemsFactory;
        private readonly EventBusService _eventBusService;

        public ItemDropperService(ItemsFactory itemsFactory, EventBusService eventBusService)
        {
            _itemsFactory = itemsFactory;
            _eventBusService = eventBusService;
            _eventBusService.Subscribe<DropItemsEvent>(SpawnItems);
        }

        public void SpawnItems(DropItemsEvent dropItemsEvent)
        {
            DroppableItem[] droppableItems = dropItemsEvent.DroppableItemsSO.DroppableItems;
            
            for (int i = 0; i < droppableItems.Length; i++)
            {
                DroppableItem item = droppableItems[i];
                
                for (int j = 0; j < item.Amount; j++)
                {
                    if (Random.Range(0f, 100f) <= item.DropRate)
                    {
                        _itemsFactory.Create(item.Config.ItemPrefab ,GetSpawnPosition(dropItemsEvent.SpawnPosition));
                    }
                }
            }
        }
        
        private Vector3 GetSpawnPosition(Transform spawnPosition)
        {
            return new Vector3(
                spawnPosition.position.x + Random.Range(-SpawnPositionOffset, SpawnPositionOffset),
                spawnPosition.position.y,
                spawnPosition.position.z + Random.Range(-SpawnPositionOffset, SpawnPositionOffset)
            );
        }

        public void Dispose()
        {
            _eventBusService.Unsubscribe<DropItemsEvent>(SpawnItems);
        }
    }
}