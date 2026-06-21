using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Enemies.SpawnerSystem
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemySpawnTagSO> _supportedSpawnTags;

        private EnemyFactory _enemyFactory;

        [Inject]
        public void Construct(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public EnemyFacade Spawn(EnemyConfigSO enemyConfigSO)
        {
            GameObject enemy = _enemyFactory.Create(enemyConfigSO, transform.position);

            return enemy.GetComponent<EnemyFacade>();
        }

        public bool CanSpawn(EnemyConfigSO enemyConfig)
        {
            return _supportedSpawnTags.Any(s => enemyConfig.SpawnTags.Contains(s));
        }
    }
}