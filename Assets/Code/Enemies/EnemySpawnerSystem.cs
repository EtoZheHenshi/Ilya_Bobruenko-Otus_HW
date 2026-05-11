using System.Collections.Generic;
using System.Linq;
using Code.GameLogic;
using UnityEngine;

namespace Code.Enemies
{
    public sealed class EnemySpawnerSystem : MonoBehaviour
    {
        [SerializeField] private EnemySpawner[] spawners;
        [SerializeField] private LevelDataSO levelData;

        public void Initialize()
        {
            for (int i = 0; i < levelData.Enemies.Count; i++)
            {
                List<EnemySpawner> supportedSpawners = GetSupportedSpawners(levelData.Enemies[i].enemyConfig);

                for (int j = 0; j < levelData.Enemies[i].count; j++)
                {
                    supportedSpawners[Random.Range(0, supportedSpawners.Count)].AddEnemy(levelData.Enemies[i].enemyConfig);
                }
            }
        }

        public void SpawnEnemy(EnemySpawner spawner, EnemyConfigSO enemyConfig)
        {
            Enemy enemy = Instantiate(enemyConfig.Prefab, spawner.transform.position, spawner.transform.rotation, spawner.transform);
            enemy.Initialize();
        }
        
        private List<EnemySpawner> GetSupportedSpawners(EnemyConfigSO enemyConfig)
        {
            return spawners.Where(s => s.CanSpawn(enemyConfig)).ToList();
        }
    }
}