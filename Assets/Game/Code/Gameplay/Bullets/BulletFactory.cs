using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Bullets
{
    public sealed class BulletFactory
    {
        private readonly DiContainer _container;
        private readonly BulletsRoot _bulletsRoot;
        private readonly GameObject _bulletPrefab;

        public BulletFactory(DiContainer container, BulletsRoot bulletsRoot, BulletConfigSO bulletConfig)
        {
            _container = container;
            _bulletsRoot = bulletsRoot;
            _bulletPrefab = bulletConfig.BulletPrefab;
        }

        public void Create(Vector3 position, Quaternion rotation)
        {
            _container.InstantiatePrefab(_bulletPrefab, position, rotation, _bulletsRoot.Transform);
        }
    }
}