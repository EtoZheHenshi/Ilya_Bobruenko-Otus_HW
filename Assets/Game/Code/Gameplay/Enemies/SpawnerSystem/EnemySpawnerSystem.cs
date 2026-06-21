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
            _spawners = GetComponentsInChildren<EnemySpawner>();
        }
        
        public List<EnemySpawner> GetSupportedSpawners(EnemyConfigSO enemyConfig)
        {
            return _spawners.Where(s => s.CanSpawn(enemyConfig)).ToList();
        }
    }
}