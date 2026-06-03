using UnityEngine;

namespace Code.PlayerLogic
{
    [CreateAssetMenu (fileName = "PlayerLvlExpTable", menuName = "Player/PlayerLvlExpTable")]
    public sealed class PlayerLvlExpTableSO : ScriptableObject
    {
        [SerializeField] private int _maxLvl;
        [SerializeField] private int _expIncreaseForHighLvl;
        [SerializeField] private int[] _lvlExpTable;
        
        public int[] LvlExpTable => _lvlExpTable;
        public int ExpIncreaseForHighLvl => _expIncreaseForHighLvl;
        public int MaxLvl => _maxLvl;
    }
}