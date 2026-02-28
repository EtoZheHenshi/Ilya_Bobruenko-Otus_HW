using System;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        
        private InputSystem _actions;

        private void Awake()
        {
            _actions = new InputSystem();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnEnable()
        {
            _actions.Enable();
            _actions.Player.Movement.performed += Movement;
            _actions.Player.Look.performed += Look;
            _actions.Player.SwitchMovementLogic.performed += SwitchMovementLogic;

            _actions.Player.Movement.canceled += Movement;
            _actions.Player.Look.canceled += Look;
        }

        private void OnDisable()
        {
            _actions.Disable();
            _actions.Player.Movement.performed -= Movement;
            _actions.Player.Look.performed -= Look;
            _actions.Player.SwitchMovementLogic.performed -= SwitchMovementLogic;

            _actions.Player.Movement.canceled -= Movement;
            _actions.Player.Look.canceled -= Look;
            
        }

        private void Movement(InputAction.CallbackContext ctx)
        {
            playerMovement.MoveDirection = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y).normalized;
        }

        private void Look(InputAction.CallbackContext ctx)
        {
            playerMovement.CameraRotationDirection = ctx.ReadValue<Vector2>();
        }
        
        private void SwitchMovementLogic(InputAction.CallbackContext ctx)
        {
            playerMovement.SwitchMovementLogic();
        }
    }
}
