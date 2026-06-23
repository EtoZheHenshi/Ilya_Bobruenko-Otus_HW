using System;
using Game.Code.Gameplay.General.Stats;
using Game.Code.Infrastructure.UpdateSystem;
using UnityEngine;

namespace Game.Code.Gameplay.Bullets
{
    public sealed class BulletMove : IUpdatable
    {
        public event Action OnEndDistance;
        
        private readonly Stat _speed;
        private readonly Stat _radius;
        private readonly Stat _maxDistance;
        private readonly LayerMask _hitMask;
        private readonly Transform _bullet;
        private readonly Action _onHitAction;

        private Vector3 _startFramePosition;
        private Vector3 _endFramePosition;
        private RaycastHit[] _hits;
        private float _currentDistance;
        
        public Vector3 StartFramePosition => _startFramePosition;
        public Vector3 EndFramePosition => _endFramePosition;
        public RaycastHit[] Hits => _hits;
        

        public BulletMove(Stat speed, Stat radius, Stat maxDistance, LayerMask hitMask, Transform bullet, Action onHitAction)
        {
            _speed = speed;
            _radius = radius;
            _maxDistance = maxDistance;
            _hitMask = hitMask;
            _bullet = bullet;
            _onHitAction = onHitAction;
        }

        public void Tick(float deltaTime)
        {
            Move(deltaTime);
        }

        public void Move(float deltaTime)
        {
            if (_currentDistance >= _maxDistance.CurrentValue)
            {
                OnEndDistance?.Invoke();
                return;
            }
            
            float moveDistance = _speed.CurrentValue * deltaTime;
            _currentDistance += moveDistance;
            
            _startFramePosition = _bullet.position;
            _endFramePosition = _bullet.position + _bullet.forward * moveDistance;
            
            _hits = Physics.SphereCastAll(
                _bullet.position,
                _radius.CurrentValue,
                _bullet.forward,
                moveDistance,
                _hitMask);

            if (_hits.Length > 0)
            {
                _onHitAction?.Invoke();
                return;
            }
            
            _bullet.position = _endFramePosition;
        }
    }
}