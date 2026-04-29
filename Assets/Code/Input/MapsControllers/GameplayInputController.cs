using System;
using UnityEngine.InputSystem;

namespace Code.Input.MapsControllers
{
    public sealed class GameplayInputController
    {
        public event Action<InputAction.CallbackContext> OnMove;
        public event Action<InputAction.CallbackContext> OnShoot;
        public event Action<InputAction.CallbackContext> OnPause;

        public GameplayInputController(PlayerInput.GameplayActions map)
        {
            map.Move.performed += OnMoveInvoke;
            
            map.Shoot.started += OnShootInvoke;
            map.Shoot.canceled += OnShootInvoke;
            
            map.Pause.started += OnPauseInvoke;
        }

        private void OnMoveInvoke(InputAction.CallbackContext ctx)
        {
            OnMove?.Invoke(ctx);
        }

        private void OnShootInvoke(InputAction.CallbackContext ctx)
        {
            OnShoot?.Invoke(ctx);
        }
        
        private void OnPauseInvoke(InputAction.CallbackContext ctx)
        {
            OnPause?.Invoke(ctx);
        }
    }
}
