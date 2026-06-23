using Game.Code.Gameplay.General.Stats;
using UnityEngine;

namespace Game.Code.Gameplay.Bullets
{
    [CreateAssetMenu(fileName = "BulletStats", menuName = "SO/Bullets/Bullet Stats")]
    public sealed class BulletStatsSO : ScriptableObject
    {
        [SerializeField] private Stat _speed;
        [SerializeField] private Stat _radius;
        [SerializeField] private Stat _distance;
        [SerializeField] private Stat _damage;
        
        public  Stat Speed => new Stat(_speed);
        public Stat Radius => new Stat(_radius);
        public Stat Distance => new Stat(_distance);
        public Stat Damage => new Stat(_damage);
    }
}