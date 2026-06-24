using Game.Code.Gameplay.Items;
using UnityEngine;

namespace Game.Code.Infrastructure.EventBusSystem.Events
{
    public class DropItemsEvent : IEvent
    {
        private readonly DroppableItemsSO _droppableItemsSO;
        private readonly Transform _spawnPosition;
        
        public DroppableItemsSO DroppableItemsSO => _droppableItemsSO;
        public Transform SpawnPosition => _spawnPosition;

        public DropItemsEvent(DroppableItemsSO droppableItemsSO, Transform spawnPosition)
        {
            _droppableItemsSO = droppableItemsSO;
            _spawnPosition = spawnPosition;
        }
    }
}