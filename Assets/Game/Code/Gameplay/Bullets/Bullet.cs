using System;
using Game.Code.Gameplay.Bullets.BulletEffects;
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

        [Inject]
        public void Construct(BulletEffectsCollection bulletEffectsCollection, UpdateService updateService)
        {
            _bulletEffectsCollection = bulletEffectsCollection;
            _updateService = updateService;
        }

        private void Start()
        {
            _bulletEffectsCollection.OnSpawn(this);
        }

        public void Tick(float deltaTime)
        {
            _bulletEffectsCollection.OnUpdate(this);
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
        }

        public void OnDestroy()
        {
            _bulletEffectsCollection.OnDestroy(this);
        }
    }

    public sealed class BulletConfigSO : ScriptableObject
    {
        [SerializeField] private BulletStatsSO _bulletStats;
        [SerializeField] private GameObject _bulletPrefab;
        
    }

    public sealed class BulletStatsSO : ScriptableObject
    {
    }
}