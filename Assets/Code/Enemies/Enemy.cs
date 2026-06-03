using Code.GeneralLogic;
using Code.PlayerLogic;
using UnityEngine;

namespace Code.Enemies
{
    [RequireComponent(
        typeof(HitFlash), 
        typeof(EnemyController)
        )
    ]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyConfigSO _config;
        private HealthSystem _healthSystem;
        private HitFlash _hitFlash;
        private EnemyController _controller;
        
        public HealthSystem HealthSystem => _healthSystem;
        
        private void Awake()
        {
            _healthSystem = new HealthSystem(_config.MaxHealth);
            _hitFlash = GetComponent<HitFlash>();
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
            
            _controller.Initialize(Player.Instance.transform);
        }

        public void TakeDamage(int damage)
        {
            _healthSystem.TakeDamage(damage);
        }

        protected virtual void Death()
        {
            Destroy(gameObject);
        }
    }
}