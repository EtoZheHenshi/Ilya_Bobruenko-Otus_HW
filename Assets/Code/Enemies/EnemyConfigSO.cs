using System.Collections.Generic;
using Code.Enemies.SpawnerSystem;
using Code.Items;
using UnityEngine;

namespace Code.Enemies
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy/EnemyConfig", order = 0)]
    public sealed class EnemyConfigSO : ScriptableObject
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private List<EnemySpawnTagSO> _spawnTags;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private DroppableItemsSO _droppableItems;
        
        public int MaxHealth => _maxHealth;
        public List<EnemySpawnTagSO> SpawnTags => _spawnTags;
        public Enemy Prefab => _enemyPrefab;
        public DroppableItemsSO DroppableItems => _droppableItems;
    }
}