using Game.Code.Gameplay.General.Stats;
using Game.Code.Infrastructure.Input;
using Game.Code.Infrastructure.UpdateSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Code.Gameplay.Player.PlayerComponents
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerMove : MonoBehaviour, IUpdatable
    {
        [SerializeField] private float _rotateSpeed = 5f;
        
        private CharacterController _controller;
        private UpdateService _updateService;
        private IInputService _inputService;
        
        private Stat _moveSpeed;
        private Vector2 _directionToMove;
        private Vector3 _directionToRotate;
        private Vector3 _lookPoint;
        private Camera _camera;
        //private bool _isShooting;
        private bool _isActive;
        
        public Stat MoveSpeed => _moveSpeed;

        [Inject]
        public void Construct(UpdateService updateService, IInputService inputService)
        {
            _controller = GetComponent<CharacterController>();
            PlayerFacade playerFacade = GetComponent<PlayerFacade>();
            _moveSpeed = playerFacade.PlayerStats.MoveSpeed;
            _camera = Camera.main;
            _updateService = updateService;
            _inputService = inputService;
        }
        
        public void Tick(float deltaTime)
        {
            if (!_isActive) return;

            Move(deltaTime);
            SetDirectionToRotate();
            //MoveCrosshair();
            Rotate(deltaTime);
        }

        private void OnEnable()
        {
            _updateService.Register(this);
            
            _inputService.PlayerInput.Gameplay.Move.performed += GameplayOnMoveListener;
            _inputService.PlayerInput.Gameplay.Move.canceled += GameplayOnMoveListener;
            
            _isActive = true;
        }

        private void OnDisable()
        {
            _isActive = false;
            
            _updateService.Unregister(this);
            
            _inputService.PlayerInput.Gameplay.Move.performed -= GameplayOnMoveListener;
            _inputService.PlayerInput.Gameplay.Move.canceled -= GameplayOnMoveListener;
        }

        public void SetActive(bool isActive)
        {
            _isActive = isActive;
        }

        private void Move(float deltaTime)
        {
            _controller.Move(new Vector3(_directionToMove.x, 0, _directionToMove.y) 
                             * (_moveSpeed.CurrentValue * deltaTime));
        }

        private void SetDirectionToRotate()
        {
            Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            Plane plane = new Plane(Vector3.up, transform.position);

            if (plane.Raycast(ray, out float distance))
            {
                _lookPoint = ray.GetPoint(distance);
                
                _directionToRotate = _lookPoint - transform.position;
                _directionToRotate.y = 0;
            }
        }

        private void Rotate(float deltaTime)
        {
            if (_directionToRotate.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_directionToRotate);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                    deltaTime * _rotateSpeed);
            }
        }
        
        private void GameplayOnMoveListener(InputAction.CallbackContext ctx)
        {
            _directionToMove = ctx.ReadValue<Vector2>().normalized;
        }
    }
}