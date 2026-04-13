using System;
using Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputLogic
{
    public sealed class GameplayInputController
    {
        public event Action<InputAction.CallbackContext> Move;
        public event Action<InputAction.CallbackContext> Start;

        private readonly PlayerInput _playerInput;

        public GameplayInputController(PlayerInput playerInput)
        {
            _playerInput = playerInput;
        }

        public void Enable()
        {
            _playerInput.Gameplay.Enable();

            _playerInput.Gameplay.Move.performed += MoveInvoke;
            _playerInput.Gameplay.Move.canceled += MoveInvoke;
            
            _playerInput.Gameplay.Start.started += StartInvoke;
        }

        public void Disable()
        {
            _playerInput.Gameplay.Disable();

            _playerInput.Gameplay.Move.performed -= MoveInvoke;
            _playerInput.Gameplay.Move.canceled -= MoveInvoke;
            
            _playerInput.Gameplay.Start.started -= StartInvoke;
        }
        
        public void Clear()
        {
            Move = null;
            Start = null;
        }

        private void MoveInvoke(InputAction.CallbackContext ctx)
        {
            Move?.Invoke(ctx);
        }
        
        private void StartInvoke(InputAction.CallbackContext ctx)
        {
            Start?.Invoke(ctx);
        }
    }
}