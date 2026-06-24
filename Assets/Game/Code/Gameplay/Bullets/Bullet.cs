using System;
using Game.Code.Gameplay.Bullets.BulletEffects;
using Game.Code.Gameplay.General;
using Game.Code.Gameplay.General.Stats;
using Game.Code.Infrastructure.UpdateSystem;
using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Bullets
{
    public sealed class Bullet : MonoBehaviour, IUpdatable
    {
        [SerializeField] private BulletConfigSO _bulletConfig;
        
        private BulletEffectsCollection _bulletEffectsCollection;
        private UpdateService _updateService;
        private BulletMove _move;
        private Stat _damage;
        
        public RaycastHit[] Hits => _move.Hits;
        public Stat Damage => _damage;

        [Inject]
        public void Construct(BulletEffectsCollection bulletEffectsCollection, UpdateService updateService,
            BulletStats bulletStats)
        {
            _bulletEffectsCollection = bulletEffectsCollection.Clone();
            _updateService = updateService;
            
            _move = new BulletMove(
                new Stat(bulletStats.Speed),
                new Stat(bulletStats.Radius),
                new Stat(bulletStats.Distance),
                _bulletConfig.HitMask,
                transform,
                OnHit);
            _move.OnEndDistance += Death;
            
            _damage = new Stat(bulletStats.Damage);
        }

        private void Start()
        {
            _bulletEffectsCollection.OnSpawn(this);
        }

        public void Tick(float deltaTime)
        {
            _bulletEffectsCollection.OnUpdate(this);
            _move.Tick(deltaTime);
        }

        private void OnEnable()
        {
            _updateService.Register(this);
        }

        private void OnDisable()
        {
            _updateService.Unregister(this);
        }

        public void OnHit()
        {
            _bulletEffectsCollection.OnHit(this);
            BaseHit();
        }

        public void OnDestroy()
        {
            _bulletEffectsCollection.OnDestroy(this);
            _move.OnEndDistance -= Death;
        }

        private void BaseHit()
        {
            if (Hits[0].transform.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage.CurrentValue);
            }
            Death();
        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}