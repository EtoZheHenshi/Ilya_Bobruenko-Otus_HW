using Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputLogic
{
    public sealed class GameplayInputController
    {
        private readonly PlayerInput _playerInput;
        private readonly Paddle _paddle;

        public GameplayInputController(PlayerInput playerInput,  Paddle paddle)
        {
            _playerInput = playerInput;
            _paddle = paddle;
        }

        public void Enable()
        {
            _playerInput.Gameplay.Enable();

            _playerInput.Gameplay.Move.performed += Move;
            _playerInput.Gameplay.Move.canceled += Move;
        }

        public void Disable()
        {
            _playerInput.Gameplay.Disable();

            _playerInput.Gameplay.Move.performed -= Move;
            _playerInput.Gameplay.Move.canceled -= Move;
        }

        private void Move(InputAction.CallbackContext ctx)
        {
            _paddle.Direction = ctx.ReadValue<Vector2>().x;
        }
    }
}