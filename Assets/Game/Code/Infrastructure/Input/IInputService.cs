using UnityEngine.InputSystem;

namespace Game.Code.Infrastructure.Input
{
    public interface IInputService
    {
        public InputActionMap CurrentMap { get; }
        public PlayerInput PlayerInput { get; }

        public void SetMap(string mapName);
    }
}