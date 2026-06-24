using Game.Code.Gameplay.General.Stats;
using UnityEngine;

namespace Game.Code.Gameplay.Bullets
{
    public sealed class BulletStats
    {
        private readonly Stat _speed;
        private readonly Stat _radius;
        private readonly Stat _distance;
        private readonly Stat _damage;
        
        public  Stat Speed => _speed;
        public Stat Radius => _radius;
        public Stat Distance => _distance;
        public Stat Damage => _damage;
        
        public BulletStats(BulletStatsSO bulletStatsSO)
        {
            _speed = bulletStatsSO.Speed;
            _radius = bulletStatsSO.Radius;
            _distance = bulletStatsSO.Distance;
            _damage = bulletStatsSO.Damage;
        }
    }
}