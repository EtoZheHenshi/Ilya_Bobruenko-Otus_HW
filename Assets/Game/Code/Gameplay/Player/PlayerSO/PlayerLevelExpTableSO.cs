using UnityEngine;

namespace Game.Code.Gameplay.Player.PlayerSO
{
    [CreateAssetMenu (fileName = "PlayerLevelExpTable", menuName = "SO/Player/PlayerLevelExpTable")]
    public sealed class PlayerLevelExpTableSO : ScriptableObject
    {
        [SerializeField] private int _maxLvl;
        [SerializeField] private int _expIncreaseForHighLvl;
        [SerializeField] private int[] _lvlExpTable;
        
        public int[] LvlExpTable => _lvlExpTable;
        public int ExpIncreaseForHighLvl => _expIncreaseForHighLvl;
        public int MaxLvl => _maxLvl;
    }
}