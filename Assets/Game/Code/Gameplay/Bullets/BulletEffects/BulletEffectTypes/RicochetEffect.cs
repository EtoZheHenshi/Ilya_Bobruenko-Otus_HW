using UnityEngine;

namespace Game.Code.Gameplay.Bullets.BulletEffects.BulletEffectTypes
{
    public sealed class RicochetEffect : BulletEffect, IBulletHitEffect
    {
        private int _maxRicochetAmount;
        private int _currentRicochetAmount;
        
        private Collider _lastRicochetCollider;

        public RicochetEffect(int maxLevel, int maxRicochetAmount) : base(maxLevel)
        {
            _maxRicochetAmount = maxRicochetAmount;
        }
        
        public void OnHit(Bullet bullet)
        {
            if (_currentRicochetAmount >= _maxRicochetAmount) 
                return;

            if (bullet.Hits[0].collider == _lastRicochetCollider)
            {
                if (bullet.Move.HitCount > 1)
                {
                    bullet.Hits[0] = bullet.Hits[1];
                }
                else
                {
                    bullet.ActivateBaseHit = false;
                    return;
                }
            }
            
            RaycastHit hit = bullet.Hits[0];
            
            Vector3 reflectedDirection = Vector3.Reflect(
                bullet.transform.forward, hit.normal).normalized;
            
            float remainingDistance = bullet.Move.MoveDistance - hit.distance;

            Vector3 bulletCenterAtHit = bullet.Move.StartFramePosition + bullet.transform.forward * hit.distance;
            
            Vector3 newPosition = bulletCenterAtHit + hit.normal * (bullet.Move.Radius.CurrentValue + Bullet.Skin);
            
            bullet.transform.rotation = Quaternion.LookRotation(reflectedDirection);

            newPosition += reflectedDirection * remainingDistance;
            
            bullet.transform.position = newPosition;
            
            bullet.ActivateDeath = false;
            _lastRicochetCollider = hit.collider;
            _currentRicochetAmount++;
        }

        public override void UpgradeEffect()
        {
            base.UpgradeEffect();
            
            _maxRicochetAmount++;
        }

        public IBulletEffect Clone()
        {
            return new RicochetEffect(MaxLevel, _maxRicochetAmount);
        }
    }   
}