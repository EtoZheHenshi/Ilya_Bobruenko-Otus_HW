using Code.GeneralLogic;
using UnityEngine;

namespace Code.Guns
{
    [CreateAssetMenu (fileName = "ShootConfig", menuName = "Guns/Shoot Configuration", order = 2)]
    public sealed class ShootConfigSO : ScriptableObject
    {
        [SerializeField] private GunStatsSO _gunStats;
        [SerializeField] private LayerMask _hitMask;
        
        public LayerMask HitMask => _hitMask;
        public Vector3 Spread => new Vector3(_gunStats.Spread.Value, 0, _gunStats.Spread.Value);
        public float FireRate => _gunStats.FireRate.Value;
    }
}