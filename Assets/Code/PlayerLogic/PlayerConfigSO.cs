using UnityEngine;

namespace Code.PlayerLogic
{
    [CreateAssetMenu (fileName = "PlayerConfig", menuName = "Player/PlayerConfig")]
    public sealed class PlayerConfigSO : ScriptableObject
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private PlayerLvlExpTableSO _playerLvlExpTable;
        
        public int MaxHealth => _maxHealth;
        public PlayerLvlExpTableSO PlayerLvlExpTable  => _playerLvlExpTable;
    }
}