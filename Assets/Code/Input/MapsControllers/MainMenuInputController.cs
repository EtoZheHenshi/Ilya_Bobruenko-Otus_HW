using System;
using UnityEngine.InputSystem;

namespace Code.Input.MapsControllers
{
    public sealed class MainMenuInputController
    {
        public event Action<InputAction.CallbackContext> OnExit;

        public MainMenuInputController(PlayerInput.MainMenuActions map)
        {
            
        }

        private void OnExitInvoke(InputAction.CallbackContext ctx)
        {
            OnExit?.Invoke(ctx);
        }
    }
}