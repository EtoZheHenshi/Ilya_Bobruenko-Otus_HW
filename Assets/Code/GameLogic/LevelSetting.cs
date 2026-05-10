using Code.Templates;
using UnityEngine;

namespace Code.GameLogic
{
    public sealed class LevelSetting : SingletonMonoBehaviour<LevelSetting>
    {
        [SerializeField] private LevelDataSO levelData;
        
        public LevelDataSO LevelData => levelData;
    }
}