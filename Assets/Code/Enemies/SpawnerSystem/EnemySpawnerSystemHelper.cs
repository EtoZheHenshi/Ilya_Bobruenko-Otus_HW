using UnityEngine;

namespace Code.Enemies.SpawnerSystem
{
    public sealed class EnemySpawnerSystemHelper : MonoBehaviour
    {
        [SerializeField] private EnemySpawnerSystem enemySpawnerSystem;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private EnemyConfigSO enemyConfig;

        public void SpawnEnemy()
        {
            enemySpawnerSystem.SpawnEnemy(enemySpawner, enemyConfig);
        }
    }
}