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

        public const float Skin = 0.02f;
        
        private BulletEffectsCollection _bulletEffectsCollection;
        private UpdateService _updateService;
        private BulletMove _move;
        private Stat _damage;
        
        public RaycastHit[] Hits => _move.Hits;
        public Stat Damage => _damage;
        public BulletMove Move => _move;
        public bool IsHitLastTarget { get; set; }
        public bool ActivateBaseHit { get; set; }
        public bool ActivateDeath { get; set; }

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
            IsHitLastTarget = true;
            ActivateBaseHit = true;
            ActivateDeath = true;
            _bulletEffectsCollection.OnHit(this);
            if (ActivateBaseHit)
            {
                BaseHit();
            }
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

            if (ActivateDeath)
            {
                Death();
            }
        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}