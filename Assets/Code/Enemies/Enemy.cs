using System;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemies
{
    [RequireComponent(typeof(EnemyHitFlash))]
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private GameObject player;
        
        private int _currentHealth;
        private EnemyHitFlash _hitFlash;
        private NavMeshAgent _agent;
        
        public int MaxHealth => maxHealth;
        public int CurrentHealth => _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
            _hitFlash = GetComponent<EnemyHitFlash>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            MoveToPlayer();
        }

        private void MoveToPlayer()
        {
            _agent.SetDestination(player.transform.position);
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                Debug.Log("Die");
            }
            _hitFlash.Flash();
        }
    }
}