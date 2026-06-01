using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class EnemyController : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Transform _target;
        
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

        public void Initialize(Transform target)
        {
            _target = target;
            _isInitialized = true;
        }

        private void MoveToPlayer()
        {
            _agent.SetDestination(_target.position);
        }
    }
}