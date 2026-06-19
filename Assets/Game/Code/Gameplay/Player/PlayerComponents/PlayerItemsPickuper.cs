using Game.Code.Gameplay.Items;
using UnityEngine;

namespace Game.Code.Gameplay.Player.PlayerComponents
{
    [RequireComponent(typeof(SphereCollider))]
    public sealed class PlayerItemsPickuper : MonoBehaviour
    {
        private PlayerFacade _playerFacade;
        
        private void Awake()
        {
            _playerFacade = GetComponent<PlayerFacade>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IPickupable pickupable))
            {
                pickupable.Pickup(_playerFacade);
            }
        }
    }
}