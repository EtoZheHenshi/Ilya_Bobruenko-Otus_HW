using System;
using Code.PlayerLogic;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class EnemyController : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            MoveToPlayer();
        }

        private void MoveToPlayer()
        {
            _agent.SetDestination(Player.Instance.transform.position);
        }
    }
}