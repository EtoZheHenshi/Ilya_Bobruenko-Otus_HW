using Game.Code.Gameplay.Player.PlayerSO;
using UnityEngine;

namespace Game.Code.Gameplay.Player
{
    public sealed class PlayerFacade : MonoBehaviour
    {
        [SerializeField] private PlayerStatsSO _playerStats;
        
        public PlayerStatsSO PlayerStats => _playerStats;
    }
}