using System;
using UnityEngine;

namespace Code.Enemies
{
    [RequireComponent(
        typeof(EnemyHealthSystem),
        typeof(EnemyHitFlash), 
        typeof(EnemyController)
        )
    ]
    public abstract class Enemy : MonoBehaviour
    {
        private EnemyHealthSystem _healthSystem;
        private EnemyHitFlash _hitFlash;
        private EnemyController _controller;

        public virtual EnemyType Type => EnemyType.None;
        
        private void Awake()
        {
            _healthSystem = GetComponent<EnemyHealthSystem>();
            _hitFlash = GetComponent<EnemyHitFlash>();
            _controller = GetComponent<EnemyController>();
        }

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            _healthSystem.OnTakeDamage += _hitFlash.Flash;
            _healthSystem.OnDeath += Death;
        }

        protected virtual void Death()
        {
            Destroy(gameObject);
        }
    }
}