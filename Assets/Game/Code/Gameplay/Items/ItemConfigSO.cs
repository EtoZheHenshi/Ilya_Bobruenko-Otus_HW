using UnityEngine;

namespace Game.Code.Gameplay.Items
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "SO/Items/Item Config")]
    public sealed class ItemConfigSO : ScriptableObject
    {
        [SerializeField] private Collider _itemPrefab;
        [SerializeField] private ItemEffectSO _itemEffect;
        [SerializeField] private float _lifeTime = 10f;
        
        public Collider ItemPrefab => _itemPrefab;
        public ItemEffectSO ItemEffect => _itemEffect;
        public float LifeTime => _lifeTime;
    }
}