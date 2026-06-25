using System.Collections.Generic;
using Game.Code.Gameplay.General;
using UnityEngine;

namespace Game.Code.Gameplay.Bullets.BulletEffects.BulletEffectTypes
{
    public sealed class PiercingEffect : BulletEffect, IBulletHitEffect
    {
        private int _maxPiercingAmount;
        private int _currentPiercingAmount;

        private List<Collider> _piercedColliders;

        public int Priority => 0;

        public PiercingEffect(int maxLevel, int maxPiercingAmount) : base(maxLevel)
        {
            _maxPiercingAmount = maxPiercingAmount;
            _piercedColliders = new List<Collider>();
        }

        public void OnHit(Bullet bullet)
        {
            if (_currentPiercingAmount > _maxPiercingAmount)
                return;

            for (int i = 0; i < bullet.Move.HitCount; i++)
            {
                if (!_piercedColliders.Contains(bullet.Hits[i].collider))
                {
                    Collider col = bullet.Hits[i].collider;
                    _piercedColliders.Add(col);
                    _currentPiercingAmount++;
                    if (_currentPiercingAmount > _maxPiercingAmount)
                    {
                        break;
                    }

                    if (col.TryGetComponent(out IDamageable damageable))
                    {
                        damageable.TakeDamage(bullet.Damage.CurrentValue);
                    }

                    if (col.gameObject.layer == LayerMask.NameToLayer("Wall"))
                    {
                        _currentPiercingAmount = _maxPiercingAmount + 1;
                        break;
                    }
                }
            }
            
            if (_currentPiercingAmount > _maxPiercingAmount)
                return;

            bullet.HitContext.IsHitLastTarget = false;
            bullet.HitContext.ActivateBaseHit = false;
            bullet.transform.position = bullet.Move.EndFramePosition;
        }

        public override void UpgradeEffect()
        {
            base.UpgradeEffect();

            _maxPiercingAmount++;
        }

        public IBulletEffect Clone()
        {
            return new PiercingEffect(MaxLevel, _maxPiercingAmount);
        }
    }
}