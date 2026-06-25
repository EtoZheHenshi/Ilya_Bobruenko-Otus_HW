using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Gameplay.Bullets.BulletEffects.BulletEffectTypes
{
    public sealed class DuplicateEffect : BulletEffect, IBulletSpawnEffect
    {
        private const float PositionOffset = 0.1f;
        private const float RotationOffset = 20f;
        
        private int _maxDuplicateAmount;
        private readonly BulletFactory _bulletFactory;
        
        public int Priority => 100;

        public DuplicateEffect(int maxLevel, int maxDuplicateAmount, BulletFactory bulletFactory) : base(maxLevel)
        {
            _maxDuplicateAmount = maxDuplicateAmount;
            _bulletFactory = bulletFactory;
        }

        public void OnSpawn(Bullet bullet)
        {
            if (bullet.HitContext.IsItDuplicate) return;
            
            {
                
            }
            for (int i = 0; i < _maxDuplicateAmount; i++)
            {
                Bullet duplicate = _bulletFactory.CreateDuplicate(bullet.transform.position, bullet.transform.rotation);
                duplicate.HitContext.IsItDuplicate = true;
                duplicate.Spawn();
                RandomizeBulletPosition(duplicate);
            }
        }

        public override void UpgradeEffect()
        {
            base.UpgradeEffect();

            _maxDuplicateAmount++;
        }

        public IBulletEffect Clone()
        {
            return new DuplicateEffect(MaxLevel, _maxDuplicateAmount, _bulletFactory);
        }

        private void RandomizeBulletPosition(Bullet bullet)
        {
            bullet.transform.position = new Vector3(
                bullet.transform.position.x + Random.Range(-PositionOffset, PositionOffset),
                bullet.transform.position.y,
                bullet.transform.position.z + Random.Range(-PositionOffset, PositionOffset)
                );
            
            bullet.transform.Rotate(0f, Random.Range(-RotationOffset, RotationOffset), 0f);
        }
    }
}