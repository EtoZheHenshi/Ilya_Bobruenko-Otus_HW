using Game.Code.Gameplay.Enemies.EnemyComponents;
using Game.Code.Gameplay.General;
using UnityEngine;

namespace Game.Code.Gameplay.Enemies
{
    public abstract class EnemyFacade : MonoBehaviour
    {
        [Header("SO")]
        [SerializeField] private EnemyConfigSO _enemyConfig;
        
        [Header("Components")]
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private HitFlash _hitFlash;
        [SerializeField] private EnemyMove _enemyMove;
        [SerializeField] private TouchAttack _touchAttack;

        public EnemyConfigSO Config => _enemyConfig;
        public EnemyStatsSO Stats => _enemyConfig.Stats;
        public EnemyHealth EnemyHealth => _enemyHealth;
        public HitFlash HitFlash => _hitFlash;
        public EnemyMove EnemyMove => _enemyMove;
        public TouchAttack TouchAttack => _touchAttack;
    }
}