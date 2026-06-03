using UnityEngine;

namespace Code.PlayerLogic
{
    [CreateAssetMenu (fileName = "PlayerConfig", menuName = "Player/PlayerConfig")]
    public sealed class PlayerConfigSO : ScriptableObject
    {
        [SerializeField] private PlayerStatsSO _playerStats;
        [SerializeField] private PlayerLvlExpTableSO _playerLvlExpTable;
        
        public PlayerStatsSO Stats => _playerStats;
        public PlayerLvlExpTableSO LvlExpTable  => _playerLvlExpTable;
    }
}