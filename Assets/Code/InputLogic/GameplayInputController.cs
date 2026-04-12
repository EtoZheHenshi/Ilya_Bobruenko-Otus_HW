using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputLogic
{
    public class GameplayInputController : MonoBehaviour
    {
        private PlayerInput _playerInput;

        private void Start()
        {
            _playerInput = InputManager.Instance.PlayerInput;
        }

        private void OnEnable()
        {
            _playerInput.Gameplay.Enable();

            _playerInput.Gameplay.Move.performed += Move;
        }

        private void OnDisable()
        {
            _playerInput.Gameplay.Disable();

            _playerInput.Gameplay.Move.performed -= Move;
        }

        private void Move(InputAction.CallbackContext obj)
        {
            throw new NotImplementedException();
        }
    }
}