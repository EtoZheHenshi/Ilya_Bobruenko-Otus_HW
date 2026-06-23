using System.Collections.Generic;

namespace Game.Code.Gameplay.Bullets.BulletEffects
{
    public sealed class BulletEffectsCollection
    {
        private List<IBulletSpawnEffect> _bulletSpawnEffects;
        private List<IBulletUpdateEffect> _bulletUpdateEffects;
        private List<IBulletHitEffect> _bulletHitEffects;
        private List<IBulletDestroyEffect> _bulletDestroyEffects;

        public BulletEffectsCollection()
        {
            _bulletSpawnEffects = new List<IBulletSpawnEffect>();
            _bulletUpdateEffects = new List<IBulletUpdateEffect>();
            _bulletHitEffects = new List<IBulletHitEffect>();
            _bulletDestroyEffects = new List<IBulletDestroyEffect>();
        }

        public void OnSpawn(Bullet bullet)
        {
            foreach (var effect in _bulletSpawnEffects)
            {
                effect.OnSpawn(bullet);
            }
        }

        public void OnUpdate(Bullet bullet)
        {
            foreach (var effect in _bulletUpdateEffects)
            {
                effect.OnUpdate(bullet);
            }
        }

        public void OnHit(Bullet bullet)
        {
            foreach (var effect in _bulletHitEffects)
            {
                effect.OnHit(bullet);
            }
        }

        public void OnDestroy(Bullet bullet)
        {
            foreach (var effect in _bulletDestroyEffects)
            {
                effect.OnDestroy(bullet);
            }
        }
        
        public void AddEffect(IBulletSpawnEffect effect)
        {
            _bulletSpawnEffects.Add(effect);
        }

        public void AddEffect(IBulletUpdateEffect effect)
        {
            _bulletUpdateEffects.Add(effect);
        }

        public void AddEffect(IBulletHitEffect effect)
        {
            _bulletHitEffects.Add(effect);
        }

        public void AddEffect(IBulletDestroyEffect effect)
        {
            _bulletDestroyEffects.Add(effect);
        }

        public void RemoveEffect(IBulletSpawnEffect effect)
        {
            _bulletSpawnEffects.Remove(effect);
        }

        public void RemoveEffect(IBulletUpdateEffect effect)
        {
            _bulletUpdateEffects.Remove(effect);
        }

        public void RemoveEffect(IBulletHitEffect effect)
        {
            _bulletHitEffects.Remove(effect);
        }

        public void RemoveEffect(IBulletDestroyEffect effect)
        {
            _bulletDestroyEffects.Remove(effect);
        }
    }
}