using UnityEngine;

namespace Game.Code.Gameplay.Bullets
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "SO/Bullets/Bullet Config")]
    public sealed class BulletConfigSO : ScriptableObject
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private LayerMask _hitMask;
        
        public GameObject BulletPrefab => _bulletPrefab;
        public LayerMask HitMask => _hitMask;
        
    }
}