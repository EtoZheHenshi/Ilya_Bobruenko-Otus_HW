using Game.Code.Gameplay.Player;
using Game.Code.Infrastructure.UpdateSystem;
using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.General
{
    public sealed class CameraMovement : MonoBehaviour, ILateUpdatable
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Vector3 _cameraOffset;
        
        private PlayerRegistry _playerRegistry;
        private UpdateService _updateService;

        [Inject]
        public void Construct(PlayerRegistry playerRegistry, UpdateService updateService)
        {
            _playerRegistry = playerRegistry;
            _updateService = updateService;
        }

        public void LateTick(float deltaTime)
        {
            SetTargetPosition();
        }

        private void OnEnable()
        {
            _updateService.Register(this);
        }

        private void OnDisable()
        {
            _updateService.Unregister(this);
        }

        private void SetTargetPosition()
        {
            _targetTransform.position = _playerRegistry.Transform.position + _cameraOffset;
        }
    }
}