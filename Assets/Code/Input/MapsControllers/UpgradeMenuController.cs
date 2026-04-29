using System;
using UnityEngine.InputSystem;

namespace Code.Input.MapsControllers
{
    public sealed class UpgradeMenuController
    {
        public event Action<InputAction.CallbackContext> OnExit;

        public UpgradeMenuController(PlayerInput.UpgradeMenuActions map)
        {
            
        }

        private void OnExitInvoke(InputAction.CallbackContext ctx)
        {
            OnExit?.Invoke(ctx);
        }
    }
}