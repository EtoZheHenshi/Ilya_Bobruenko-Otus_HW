using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Enemies.SpawnerSystem
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemySpawnTagSO> supportedSpawnTags;

        public Enemy Spawn(EnemyConfigSO enemyConfig)
        {
            Enemy enemy = Instantiate(enemyConfig.Prefab, transform.position, transform.rotation, transform);
            enemy.Initialize();

            return enemy;
        }

        public bool CanSpawn(EnemyConfigSO enemyConfig)
        {
            return supportedSpawnTags.Any(s => enemyConfig.SpawnTags.Contains(s));
        }
    }
}