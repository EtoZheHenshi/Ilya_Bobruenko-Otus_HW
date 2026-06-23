using Game.Code.Gameplay.General.Stats;
using UnityEngine;

namespace Game.Code.Gameplay.Player.PlayerSO
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "SO/Player/Player Stats")]
    public sealed class PlayerStatsSO : ScriptableObject
    {
        [SerializeField] private Stat _moveSpeed;
        [SerializeField] private Stat _maxHealth;
        [SerializeField] private Stat _fireRate;
        
        public Stat MoveSpeed => new Stat(_moveSpeed);
        public Stat MaxHealth => new Stat(_maxHealth);
        public Stat FireRate => new Stat(_fireRate);
    }
}