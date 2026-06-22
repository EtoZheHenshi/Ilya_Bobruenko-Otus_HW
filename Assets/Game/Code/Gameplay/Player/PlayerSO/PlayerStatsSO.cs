using Game.Code.Gameplay.General.Stats;
using UnityEngine;

namespace Game.Code.Gameplay.Player.PlayerSO
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "SO/Player/Player Stats")]
    public sealed class PlayerStatsSO : ScriptableObject
    {
        [SerializeField] private Stat _moveSpeed;
        [SerializeField] private Stat _maxHealth;
        
        public Stat MoveSpeed => new Stat(_moveSpeed);
        public Stat MaxHealth => new Stat(_maxHealth);
    }
}