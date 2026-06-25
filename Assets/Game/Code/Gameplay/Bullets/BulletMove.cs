using System;
using System.Collections.Generic;
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
        private int _hitCount;
        private float _currentDistance;
        private float _moveDistance;
        
        public Vector3 StartFramePosition => _startFramePosition;
        public Vector3 EndFramePosition => _endFramePosition;
        public float MoveDistance => _moveDistance;
        public RaycastHit[] Hits => _hits;
        public int HitCount => _hitCount;
        public Stat Speed => _speed;
        public Stat Radius => _radius;
        public Stat MaxDistance => _maxDistance;
        

        public BulletMove(Stat speed, Stat radius, Stat maxDistance, LayerMask hitMask, Transform bullet, Action onHitAction)
        {
            _speed = speed;
            _radius = radius;
            _maxDistance = maxDistance;
            _hitMask = hitMask;
            _bullet = bullet;
            _onHitAction = onHitAction;
            
            _hits = new RaycastHit[32];
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
            
            _moveDistance = _speed.CurrentValue * deltaTime;
            _currentDistance += _moveDistance;
            
            _startFramePosition = _bullet.position;
            _endFramePosition = _bullet.position + _bullet.forward * _moveDistance;
            
            _hitCount = Physics.SphereCastNonAlloc(
                _bullet.position,
                _radius.CurrentValue,
                _bullet.forward,
                _hits,
                _moveDistance,
                _hitMask);

            if (_hitCount > 0)
            {
                SortHitsByDistance();
                _onHitAction?.Invoke();
                return;
            }
            
            _bullet.position = _endFramePosition;
        }
        
        private void SortHitsByDistance()
        {
            Array.Sort(_hits, 0, _hitCount, Comparer<RaycastHit>.Create(CompareHits));
        }

        private static int CompareHits(RaycastHit a, RaycastHit b)
        {
            return a.distance.CompareTo(b.distance);
        }
    }
}