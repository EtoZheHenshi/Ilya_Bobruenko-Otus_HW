using System;
using Game.Code.Gameplay.General.Stats;
using Game.Code.Infrastructure.UpdateSystem;
using UnityEngine;

namespace Game.Code.Gameplay.Bullets
{
    public sealed class BulletMove : IUpdatable
    {
        private readonly Stat _speed;
        private readonly LayerMask _hitMask;
        private readonly Stat _radius;
        private readonly Transform _bullet;
        private Vector3 _direction;
        private readonly Action _onHitAction;
        

        public BulletMove(Stat speed, LayerMask hitMask, Stat radius, Transform bullet,
            Vector3 direction, Action onHitAction)
        {
            _speed = speed;
            _hitMask = hitMask;
            _radius = radius;
            _bullet = bullet;
            _direction = direction;
            _onHitAction = onHitAction;
        }

        public void Tick(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void Move(float deltaTime)
        {
            float moveDistance = _speed.CurrentValue + deltaTime;

            if (Physics.SphereCast(
                    _bullet.position,
                    _radius.CurrentValue,
                    _direction,
                    out RaycastHit hit,
                    moveDistance,
                    _hitMask))
            {
                _onHitAction?.Invoke();
                return;
            }
            
            _bullet.position += _direction * moveDistance;
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
    }
}