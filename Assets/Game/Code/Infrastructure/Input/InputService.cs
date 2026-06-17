using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Code.Infrastructure.Input
{
    public sealed class InputService : IInputService
    {
        private readonly PlayerInput _playerInput;
        
        public InputActionMap CurrentMap { get; private set; }
        public PlayerInput PlayerInput => _playerInput;

        public InputService()
        {
            _playerInput = new PlayerInput();

            foreach (InputActionMap map in _playerInput.asset.actionMaps)
            {
                map.Disable();
            }
        }

        public void SetMap(string mapName)
        {
            InputActionMap map = _playerInput.asset.FindActionMap(mapName);

            if (map == null)
            {
                Debug.LogWarning("Map not found: " + mapName);
                return;
            }
            
            CurrentMap?.Disable();
            CurrentMap = map;
            CurrentMap.Enable();
        }
    }
}