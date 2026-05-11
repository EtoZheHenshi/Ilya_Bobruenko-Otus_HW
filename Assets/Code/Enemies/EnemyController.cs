using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class EnemyController : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Transform _target;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            MoveToPlayer();
        }

        public void Initialize(Transform target)
        {
            _target = target;
        }

        private void MoveToPlayer()
        {
            _agent.SetDestination(_target.position);
        }
    }
}