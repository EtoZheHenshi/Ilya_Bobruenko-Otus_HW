using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Code.Gameplay.Bullets.BulletEffects
{
    public sealed class BulletEffectsCollection
    {
        private readonly List<IBulletSpawnEffect> _bulletSpawnEffects;
        private readonly List<IBulletUpdateEffect> _bulletUpdateEffects;
        private readonly List<IBulletHitEffect> _bulletHitEffects;
        private readonly List<IBulletDestroyEffect> _bulletDestroyEffects;

        public BulletEffectsCollection()
        {
            _bulletSpawnEffects = new List<IBulletSpawnEffect>();
            _bulletUpdateEffects = new List<IBulletUpdateEffect>();
            _bulletHitEffects = new List<IBulletHitEffect>();
            _bulletDestroyEffects = new List<IBulletDestroyEffect>();
        }

        private BulletEffectsCollection(BulletEffectsCollection old)
        {
            _bulletSpawnEffects = old._bulletSpawnEffects.Select(
                ef => (IBulletSpawnEffect)ef.Clone()).ToList();
            _bulletUpdateEffects = old._bulletUpdateEffects.Select(
                ef => (IBulletUpdateEffect)ef.Clone()).ToList();
            _bulletHitEffects = old._bulletHitEffects.Select(
                ef => (IBulletHitEffect)ef.Clone()).ToList();
            _bulletDestroyEffects = old._bulletDestroyEffects.Select(
                ef => (IBulletDestroyEffect)ef.Clone()).ToList();
        }

        public BulletEffectsCollection Clone()
        {
            return new BulletEffectsCollection(this);
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

        public void Add(BulletEffect effect)
        {
            if (effect is IBulletSpawnEffect spawn)
            {
                _bulletSpawnEffects.Add(spawn);
                _bulletSpawnEffects.Sort(CompareEffects);
            }

            if (effect is IBulletUpdateEffect update)
            {
                _bulletUpdateEffects.Add(update);
            }

            if (effect is IBulletHitEffect hit)
            {
                _bulletHitEffects.Add(hit);
            }

            if (effect is IBulletDestroyEffect destroy)
            {
                _bulletDestroyEffects.Add(destroy);
            }
        }

        public void Remove(BulletEffect effect)
        {
            if (effect is IBulletSpawnEffect spawn)
            {
                _bulletSpawnEffects.Remove(spawn);
            }

            if (effect is IBulletUpdateEffect update)
            {
                _bulletUpdateEffects.Remove(update);
            }

            if (effect is IBulletHitEffect hit)
            {
                _bulletHitEffects.Remove(hit);
            }

            if (effect is IBulletDestroyEffect destroy)
            {
                _bulletDestroyEffects.Remove(destroy);
            }
        }

        public bool Contains(BulletEffect effect)
        {
            if (effect is IBulletSpawnEffect spawn)
            {
                return _bulletSpawnEffects.Contains(spawn);
            }

            if (effect is IBulletUpdateEffect update)
            {
                return _bulletUpdateEffects.Contains(update);
            }

            if (effect is IBulletHitEffect hit)
            {
                return _bulletHitEffects.Contains(hit);
            }

            if (effect is IBulletDestroyEffect destroy)
            {
                return _bulletDestroyEffects.Contains(destroy);
            }
            
            return false;
        }

        private int CompareEffects(IBulletEffect a, IBulletEffect b)
        {
            return b.Priority.CompareTo(a.Priority);
        }
    }
}