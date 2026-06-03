using UnityEngine;

namespace Code.Items
{
    [CreateAssetMenu (fileName = "ItemConfig", menuName = "Items/ItemConfig")]
    public sealed class ItemConfig : ScriptableObject
    {
        [SerializeField] private Collider _itemPrefab;
        [SerializeField] private ItemEffectSO _itemEffect;
        [SerializeField] private float _lifeTime = 10f;
        
        public Collider ItemPrefab => _itemPrefab;
        public ItemEffectSO ItemEffect => _itemEffect;
        public float LifeTime => _lifeTime;
    }
}