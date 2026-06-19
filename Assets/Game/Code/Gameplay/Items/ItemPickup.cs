using System.Collections;
using UnityEngine;
using Game.Code.Gameplay.Player;

namespace Game.Code.Gameplay.Items
{
    public sealed class ItemPickup : MonoBehaviour, IPickupable
    {
        [SerializeField] private ItemConfigSO _itemConfig;

        private void OnEnable()
        {
            StartCoroutine(StartLifeTimer());
        }

        public void Pickup(PlayerFacade playerFacade)
        {
            _itemConfig.ItemEffect.Apply(playerFacade);
            
            Destroy(gameObject);
        }

        private IEnumerator StartLifeTimer()
        {
            yield return new WaitForSeconds(_itemConfig.LifeTime);
            
            Destroy(gameObject);
        }
    }
}