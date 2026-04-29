using System;
using Code.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Player
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        [SerializeField] private float moveSpeed;

        private Vector2 _directionToMove;
        private Vector3 _directionToRotate;
        private Camera _camera;

        private void Start()
        {
            InputManager.Instance.Gameplay.OnMove += GameplayOnMoveListener;
            _camera = Camera.main;
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            controller.Move(new Vector3(_directionToMove.x, 0, _directionToMove.y) * (moveSpeed * Time.deltaTime));
        }

        private void GameplayOnMoveListener(InputAction.CallbackContext ctx)
        {
            _directionToMove = ctx.ReadValue<Vector2>().normalized;
        }
        
        private void Rotate()
        {
            SetDirectionToRotate();
            
            Quaternion targetRotation = Quaternion.LookRotation(_directionToRotate);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }

        private void SetDirectionToRotate()
        {
            Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            Plane plane = new Plane(Vector3.up, transform.position);

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 point = ray.GetPoint(distance);
                
                _directionToRotate = point - transform.position;
                _directionToRotate.y = 0;
            }
        }
    }
}