using System.Collections.Generic;
using UnityEngine;

namespace Code.Enemies
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy/EnemyConfig", order = 0)]
    public sealed class EnemyConfigSO : ScriptableObject
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private List<EnemySpawnTagSO> spawnTags;
        [SerializeField] private Enemy enemyPrefab;
        
        public int MaxHealth => maxHealth;
        public List<EnemySpawnTagSO> SpawnTags => spawnTags;
        public Enemy Prefab => enemyPrefab;
    }
}