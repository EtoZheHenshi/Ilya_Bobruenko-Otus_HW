using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Items
{
    public sealed class ItemDropper : MonoBehaviour
    {
        [SerializeField] private float _spawnPositionOffset = 1f;
        [SerializeField] private DroppableItemsSO _droppableItemsSO;
        
        private ItemsRoot _itemsRoot;
        private ItemsFactory _itemsFactory;

        [Inject]
        public void Construct(ItemsRoot itemsRoot, ItemsFactory itemsFactory)
        {
            _itemsRoot = itemsRoot;
            _itemsFactory = itemsFactory;
        }

        public void SpawnItems()
        {
            DroppableItem[] droppableItems = _droppableItemsSO.DroppableItems;
            
            for (int i = 0; i < droppableItems.Length; i++)
            {
                DroppableItem item = droppableItems[i];
                
                for (int j = 0; j < item.Amount; j++)
                {
                    if (Random.Range(0f, 100f) <= item.DropRate)
                    {
                        _itemsFactory.Create(item.Config.ItemPrefab ,GetSpawnPosition(transform), _itemsRoot.Transform);
                    }
                }
            }
        }
        
        private Vector3 GetSpawnPosition(Transform spawnPosition)
        {
            return new Vector3(
                spawnPosition.position.x + Random.Range(-_spawnPositionOffset, _spawnPositionOffset),
                spawnPosition.position.y,
                spawnPosition.position.z + Random.Range(-_spawnPositionOffset, _spawnPositionOffset)
            );
        }
        
    }
}