using System;
using UnityEngine.InputSystem;

namespace Code.Input.MapsControllers
{
    public sealed class PauseMenuInputController
    {
        public event Action<InputAction.CallbackContext> OnExit;

        public PauseMenuInputController(PlayerInput.PauseMenuActions map)
        {
            
        }

        private void OnExitInvoke(InputAction.CallbackContext ctx)
        {
            OnExit?.Invoke(ctx);
        }
    }
}