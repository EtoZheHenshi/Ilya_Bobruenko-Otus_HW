using System.Collections.Generic;
using Code.Enemies.SpawnerSystem;
using Code.GeneralLogic;
using Code.Items;
using UnityEngine;

namespace Code.Enemies
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy/EnemyConfig", order = 0)]
    public sealed class EnemyConfigSO : ScriptableObject
    {
        [SerializeField] private EnemyStatsSO _enemyStats;
        [SerializeField] private List<EnemySpawnTagSO> _spawnTags;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private DroppableItemsSO _droppableItems;

        public EnemyStatsSO Stats => _enemyStats;
        public List<EnemySpawnTagSO> SpawnTags => _spawnTags;
        public Enemy Prefab => _enemyPrefab;
        public DroppableItemsSO DroppableItems => _droppableItems;
    }
}