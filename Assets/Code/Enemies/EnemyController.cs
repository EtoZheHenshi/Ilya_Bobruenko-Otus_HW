using Code.GeneralLogic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class EnemyController : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Transform _target;
        private Stat _moveSpeed; 
        
        private bool _isInitialized;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(!_isInitialized) return;
            MoveToPlayer();
        }

        public void Initialize(Transform target, Stat moveSpeed)
        {
            _target = target;
            _moveSpeed = moveSpeed;
            _isInitialized = true;
        }

        private void MoveToPlayer()
        {
            _agent.speed = _moveSpeed.Value;
            _agent.SetDestination(_target.position);
        }
    }
}