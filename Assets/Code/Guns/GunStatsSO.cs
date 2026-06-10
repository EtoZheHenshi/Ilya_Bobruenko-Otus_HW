using Code.GeneralLogic;
using UnityEngine;

namespace Code.Guns
{
    [CreateAssetMenu(fileName = "GunStats", menuName = "Guns/GunStats")]
    public sealed class GunStatsSO : ScriptableObject
    {
        [SerializeField] private Stat _damage;
        [SerializeField] private Stat _fireRate;
        [SerializeField] private Stat _spread;
        [SerializeField] private Stat _distance;
        
        public Stat Damage => _damage;
        public Stat FireRate => _fireRate;
        public Stat Spread => _spread;
        public Stat Distance => _distance;

        public void ClearStats()
        {
            _damage.ClearModifiers();
            _fireRate.ClearModifiers();
            _spread.ClearModifiers();
            _distance.ClearModifiers();
        }
    }
}