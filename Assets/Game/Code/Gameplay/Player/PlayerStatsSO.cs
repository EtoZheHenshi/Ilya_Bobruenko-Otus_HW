using Game.Code.Gameplay.General.Stats;
using UnityEngine;

namespace Game.Code.Gameplay.Player
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "SO/Player/Player Stats")]
    public sealed class PlayerStatsSO : ScriptableObject
    {
        [SerializeField] private Stat _moveSpeed;
        
        public Stat MoveSpeed => _moveSpeed;
    }
}