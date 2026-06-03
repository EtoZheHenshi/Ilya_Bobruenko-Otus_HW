using System;
using System.Collections;
using Code.GeneralLogic;
using Code.PlayerLogic;
using UnityEngine;

namespace Code.Items
{
    [RequireComponent(typeof(Collider))]
    public sealed class ItemPickup : MonoBehaviour, IPickupable
    {
        [SerializeField] private ItemConfig _itemConfig;

        private void Start()
        {
            StartCoroutine(StartLifeTimer());
        }

        public void Pickup(Player player)
        {
            _itemConfig.ItemEffect.Apply(player);

            Destroy(gameObject);
        }

        private IEnumerator StartLifeTimer()
        {
            yield return new WaitForSeconds(_itemConfig.LifeTime);
            
            Destroy(gameObject);
        }
    }
}