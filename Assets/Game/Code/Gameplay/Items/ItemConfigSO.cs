using UnityEngine;

namespace Game.Code.Gameplay.Items
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "SO/Items/Item Config")]
    public sealed class ItemConfigSO : ScriptableObject
    {
        [SerializeField] private ItemPickup _itemPrefab;
        [SerializeField] private ItemEffectSO _itemEffect;
        [SerializeField] private float _lifeTime = 10f;
        
        public ItemPickup ItemPrefab => _itemPrefab;
        public ItemEffectSO ItemEffect => _itemEffect;
        public float LifeTime => _lifeTime;
    }
}