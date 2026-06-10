using System;
using UnityEngine.InputSystem;

namespace Code.Input.MapsControllers
{
    public sealed class PauseMenuInputController
    {
        public event Action<InputAction.CallbackContext> OnCloseMenu;

        public PauseMenuInputController(PlayerInput.PauseMenuActions map)
        {
            map.CloseMenu.started += OnCloseMenuInvoke;
        }

        private void OnCloseMenuInvoke(InputAction.CallbackContext ctx)
        {
            OnCloseMenu?.Invoke(ctx);
        }
    }
}