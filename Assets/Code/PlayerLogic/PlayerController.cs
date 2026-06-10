using Code.GameLogic;
using Code.GeneralLogic;
using Code.Guns;
using Code.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.PlayerLogic
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private Transform _crosshair;

        [Space] 
        [SerializeField] private PlayerGunSelector _gunSelector;

        private Stat _moveSpeed;
        private Vector2 _directionToMove;
        private Vector3 _directionToRotate;
        private Vector3 _lookPoint;
        private Camera _camera;
        private bool _isShooting;
        private bool _isInitialized;

        private void Update()
        {
            if (!_isInitialized) return;
            if(GameState.CurrentGameState != GameStateType.Gameplay) return;
            
            Move();
            SetDirectionToRotate();
            MoveCrosshair();
            Rotate();
            Shoot();
        }

        public void Initialize(Stat moveSpeed)
        {
            _moveSpeed = moveSpeed;
            InputManager.Instance.Gameplay.OnMove += GameplayOnMoveListener;
            InputManager.Instance.Gameplay.OnShoot += GameplayOnShootListener;
            _camera = Camera.main;
            _isInitialized = true;
        }

        private void Move()
        {
            _controller.Move(new Vector3(_directionToMove.x, 0, _directionToMove.y) * (_moveSpeed.Value * Time.deltaTime));
        }
        
        private void Rotate()
        {
            if (_directionToRotate.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_directionToRotate);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }

        private void MoveCrosshair()
        {
            _crosshair.position = new Vector3(_lookPoint.x, _crosshair.position.y, _lookPoint.z);
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
        
        private void GameplayOnMoveListener(InputAction.CallbackContext ctx)
        {
            _directionToMove = ctx.ReadValue<Vector2>().normalized;
        }

        private void GameplayOnShootListener(InputAction.CallbackContext ctx)
        {
            if (ctx.started) _isShooting = true;
            if (ctx.canceled) _isShooting = false;
        }

        public void Shoot()
        {
            if (_isShooting && _gunSelector.ActiveGun != null)
            {
                _gunSelector.ActiveGun.Shoot();
            }
        }
    }
}