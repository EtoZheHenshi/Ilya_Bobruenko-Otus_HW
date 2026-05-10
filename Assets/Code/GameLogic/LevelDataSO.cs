using System;
using System.Collections.Generic;
using Code.Enemies;
using UnityEngine;

namespace Code.GameLogic
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "GameplayData/LevelData")]
    public sealed class LevelDataSO : ScriptableObject
    {
        [SerializeField] private List<EnemyCount> enemyCount;

        public List<EnemyCount> Enemies => enemyCount;
        
        [Serializable]
        public sealed class EnemyCount
        {
            public EnemyType enemyType;
            public int count;
        }
    }
}