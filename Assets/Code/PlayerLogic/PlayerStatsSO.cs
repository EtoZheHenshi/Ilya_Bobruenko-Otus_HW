using Code.GeneralLogic;
using UnityEngine;

namespace Code.PlayerLogic
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats")]
    public sealed class PlayerStatsSO : ScriptableObject
    {
        [SerializeField] private Stat _maxHealth;
        [SerializeField] private Stat _moveSpeed;
        
        public Stat MaxHealth => _maxHealth;
        public Stat MoveSpeed => _moveSpeed;

        public void ClearStats()
        {
            _maxHealth.ClearModifiers();
            _moveSpeed.ClearModifiers();
        }
    }
}