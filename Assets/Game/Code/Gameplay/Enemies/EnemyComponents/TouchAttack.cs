using Game.Code.Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Enemies.EnemyComponents
{
    [RequireComponent(typeof(Collider))]
    public sealed class TouchAttack : MonoBehaviour
    {
        [SerializeField] private float _damage = 1f;
        private PlayerRegistry _playerRegistry;

        [Inject]
        public void Construct(PlayerRegistry playerRegistry)
        {
            _playerRegistry = playerRegistry;
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _playerRegistry.Damageable.TakeDamage(_damage);
            }
        }
    }
}