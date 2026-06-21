using UnityEngine;

namespace Game.Code.Gameplay.Enemies
{
    [CreateAssetMenu (fileName = "EnemyTypes", menuName = "SO/Enemies/Enemy Types")]
    public sealed class EnemyTypesSO : ScriptableObject
    {
        [SerializeField] private EnemyConfigSO[] _enemyTypes;

        public EnemyConfigSO[] EnemyTypes => _enemyTypes;
    }
}