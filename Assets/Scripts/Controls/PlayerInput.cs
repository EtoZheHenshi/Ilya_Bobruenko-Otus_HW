using System;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        private GameInputSystem _inputSystem;

        void Awake()
        {
            _inputSystem = new GameInputSystem();
        }

        private void OnEnable()
        {
            _inputSystem.Player.Enable();
            //_inputSystem.Player.Move.performed += Move;
            //_inputSystem.Player.Move.canceled += Move;
            //_inputSystem.Player.Sprint.performed += Sprint;
            //_inputSystem.Player.Attack.performed += Attack;
            _inputSystem.Player.Look.performed += Look;
            _inputSystem.Player.Look.canceled += Look;
        }

        private void OnDisable()
        {
            _inputSystem.Player.Disable();
            //_inputSystem.Player.Move.performed -= Move;
            //_inputSystem.Player.Move.canceled -= Move;
            //_inputSystem.Player.Sprint.performed -= Sprint;
            //_inputSystem.Player.Attack.performed -= Attack;
            _inputSystem.Player.Look.performed -= Look;
            _inputSystem.Player.Look.canceled -= Look;
        }

        private void Move(InputAction.CallbackContext ctx)
        {
            throw new NotImplementedException();
        }

        private void Sprint(InputAction.CallbackContext ctx)
        {
            throw new NotImplementedException();
        }

        private void Attack(InputAction.CallbackContext ctx)
        {
            throw new NotImplementedException();
        }
        
        private void Look(InputAction.CallbackContext ctx)
        {
            playerController.CameraRotation = ctx.ReadValue<Vector2>();
        }
    }
}
