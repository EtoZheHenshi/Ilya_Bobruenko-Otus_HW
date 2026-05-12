using System;
using System.Collections.Generic;
using System.Linq;
using Code.GameLogic;
using UnityEngine;

namespace Code.Enemies
{
    public sealed class EnemySpawnerSystem : MonoBehaviour
    {
        private EnemySpawner[] _spawners;

        private void Awake()
        {
            _spawners = GetComponentsInChildren<EnemySpawner>();
        }

        public void SpawnEnemy(EnemySpawner spawner, EnemyConfigSO enemyConfig)
        {
            Enemy enemy = Instantiate(enemyConfig.Prefab, spawner.transform.position, spawner.transform.rotation, spawner.transform);
            enemy.Initialize();
        }
        
        public List<EnemySpawner> GetSupportedSpawners(EnemyConfigSO enemyConfig)
        {
            return _spawners.Where(s => s.CanSpawn(enemyConfig)).ToList();
        }
    }
}