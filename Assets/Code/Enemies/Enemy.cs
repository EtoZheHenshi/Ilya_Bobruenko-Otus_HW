using Code.PlayerLogic;
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
        [SerializeField] private EnemyConfigSO config;
        private EnemyHealthSystem _healthSystem;
        private EnemyHitFlash _hitFlash;
        private EnemyController _controller;
        
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
            _healthSystem.Initialize(config.MaxHealth);
            _healthSystem.OnTakeDamage += _hitFlash.Flash;
            _healthSystem.OnDeath += Death;
            
            _controller.Initialize(Player.Instance.transform);
        }

        protected virtual void Death()
        {
            Destroy(gameObject);
        }
    }
}