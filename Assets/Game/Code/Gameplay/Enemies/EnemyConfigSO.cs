using System.Collections.Generic;
using Game.Code.Gameplay.Enemies.SpawnerSystem;
using Game.Code.Gameplay.Items;
using UnityEngine;

namespace Game.Code.Gameplay.Enemies
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "SO/Enemies/Enemy Config")]
    public sealed class EnemyConfigSO : ScriptableObject
    {
        [SerializeField] private EnemyStatsSO _enemyStats;
        [SerializeField] private List<EnemySpawnTagSO> _spawnTags;
        [SerializeField] private EnemyFacade _enemyPrefab;
        [SerializeField] private DroppableItemsSO _droppableItems;

        public EnemyStatsSO Stats => _enemyStats;
        public List<EnemySpawnTagSO> SpawnTags => _spawnTags;
        public EnemyFacade Prefab => _enemyPrefab;
        public DroppableItemsSO DroppableItems => _droppableItems;
    }
}