using UnityEngine;

namespace Code.Items
{
    public sealed class DropSystem
    {
        private static readonly GameObject ItemsParent;
        private const float SpawnPositionOffset = 1f;
        
        private readonly DroppableItem[] _droppableItems;
        private readonly Transform _spawnPosition;

        static DropSystem()
        {
            ItemsParent = new GameObject("[Items]");
        }

        public DropSystem(DroppableItem[] droppableItems, Transform spawnPosition)
        {
            _droppableItems = droppableItems;
            _spawnPosition = spawnPosition;
        }

        public void CreateDrop()
        {
            for (int i = 0; i < _droppableItems.Length; i++)
            {
                DroppableItem item = _droppableItems[i];
                
                for (int j = 0; j < item.Count; j++)
                {
                    if (Random.Range(0f, 100f) <= item.DropRate)
                    {
                        Object.Instantiate(item.Config.ItemPrefab, GetSpawnPosition(_spawnPosition),
                            Quaternion.identity, ItemsParent.transform);
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
    }
}