using UnityEngine;

namespace Code.Items
{
    [CreateAssetMenu (fileName = "ItemConfig", menuName = "Items/ItemConfig")]
    public sealed class ItemConfig : ScriptableObject
    {
        [SerializeField] private Collider _itemPrefab;
        [SerializeField] private ItemEffect _itemEffect;
        
        public Collider ItemPrefab => _itemPrefab;
        public ItemEffect ItemEffect => _itemEffect;
    }
}