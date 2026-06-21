using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Enemies
{
    public sealed class EnemyFactory
    {
        private readonly DiContainer _container;
        private readonly EnemiesRoot _enemiesRoot;

        public EnemyFactory(DiContainer container, EnemiesRoot enemiesRoot)
        {
            _container = container;
            _enemiesRoot = enemiesRoot;
        }
        
        public GameObject Create(EnemyConfigSO enemyConfig, Vector3 position)
        {
            return _container.InstantiatePrefab(enemyConfig.Prefab, position, Quaternion.identity, _enemiesRoot.Transform);
        }
    }
}