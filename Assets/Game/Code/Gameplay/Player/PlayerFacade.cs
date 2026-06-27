using Game.Code.Gameplay.General;
using Game.Code.Gameplay.Player.PlayerComponents;
using Game.Code.Gameplay.Player.PlayerSO;
using UnityEngine;

namespace Game.Code.Gameplay.Player
{
    public sealed class PlayerFacade : MonoBehaviour
    {
        [Header("SO")]
        [SerializeField] private PlayerStatsSO _playerStats;
        
        [Header("Components")]
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerItemsPickuper _itemsPickuper;
        [SerializeField] private PlayerLevel _playerLevel;
        [SerializeField] private PlayerMove _playerMove;
        [SerializeField] private HitFlash _hitFlash;
        [SerializeField] private PlayerShoot _playerShoot;
        [SerializeField] private PlayerAnimator _playerAnimator;
        
        public PlayerStatsSO PlayerStats => _playerStats;
        public PlayerHealth PlayerHealth => _playerHealth;
        public PlayerItemsPickuper ItemsPickuper => _itemsPickuper;
        public PlayerLevel PlayerLevel => _playerLevel;
        public PlayerMove PlayerMove => _playerMove;
        public HitFlash HitFlash => _hitFlash;
        public PlayerShoot PlayerShoot => _playerShoot;
        public PlayerAnimator PlayerAnimator => _playerAnimator;
    }
}