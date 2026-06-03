using Code.GeneralLogic;
using Code.PlayerLogic;
using UnityEngine;

namespace Code.Items
{
    [RequireComponent(typeof(Collider))]
    public sealed class ItemPickup : MonoBehaviour, IPickupable
    {
        [SerializeField] private ItemConfig _itemConfig;


        public void Pickup(Player player)
        {
            _itemConfig.ItemEffect.Apply(player);
            
            Destroy(gameObject);
        }
    }
}