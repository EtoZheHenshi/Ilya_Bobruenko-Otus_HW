using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Enemies
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemySpawnTagSO> supportedSpawnTags;

        private List<EnemyConfigSO> _enemyStorage;

        public void Spawn()
        {
            EnemyConfigSO enemyConfig = _enemyStorage[Random.Range(0, _enemyStorage.Count)];
            _enemyStorage.Remove(enemyConfig);
            
            Enemy enemy = Instantiate(enemyConfig.Prefab, transform.position, transform.rotation, transform);
            enemy.Initialize();
        }

        public bool CanSpawn(EnemyConfigSO enemyConfig)
        {
            return supportedSpawnTags.Any(s => enemyConfig.SpawnTags.Contains(s));
        }

        public void AddEnemy(EnemyConfigSO enemyConfig)
        {
            _enemyStorage.Add(enemyConfig);
        }
    }
}