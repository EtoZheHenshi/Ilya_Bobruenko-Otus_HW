using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Enemies.SpawnerSystem
{
    public sealed class EnemySpawnerSystem : MonoBehaviour
    {
        private EnemySpawner[] _spawners;

        [Inject]
        public void Construct()
        {
            _spawners = FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);
        }
        
        public List<EnemySpawner> GetSupportedSpawners(EnemyConfigSO enemyConfig)
        {
            return _spawners.Where(s => s.CanSpawn(enemyConfig)).ToList();
        }
    }
}