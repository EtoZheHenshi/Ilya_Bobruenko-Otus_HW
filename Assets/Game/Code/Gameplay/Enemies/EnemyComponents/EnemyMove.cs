using System;
using Game.Code.Gameplay.General.Stats;
using Game.Code.Gameplay.Player;
using Game.Code.Infrastructure.UpdateSystem;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Game.Code.Gameplay.Enemies.EnemyComponents
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class EnemyMove : MonoBehaviour, IUpdatable
    {
        private UpdateService _updateService;
        
        private NavMeshAgent _agent;
        private Transform _target;
        private Stat _speed;

        [Inject]
        public void Construct(PlayerRegistry player, UpdateService updateService)
        {
            _updateService = updateService;
            _agent = GetComponent<NavMeshAgent>();
            _target = player.Transform;
            EnemyFacade enemy = GetComponent<EnemyFacade>();
            _speed = enemy.Stats.Speed;
        }
        
        public void Tick(float deltaTime)
        {
            MoveToPlayer();
        }

        private void OnEnable()
        {
            _updateService.Register(this);
        }

        private void OnDisable()
        {
            _updateService.Unregister(this);
        }

        private void MoveToPlayer()
        {
            _agent.speed = _speed.CurrentValue;
            _agent.SetDestination(_target.position);
        }
    }
}