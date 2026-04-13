using Gameplay;
using UnityEngine;

namespace InputLogic
{
    public sealed class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }
        public GameplayInputController GameplayInput { get; private set; }

        private PlayerInput _playerInput;
        
        private void Awake()
        {
            if (Instance !=null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            _playerInput = new PlayerInput();
            _playerInput.Enable();
            
            GameplayInput = new GameplayInputController(_playerInput);
            GameplayInput.Enable();
        }

        private void OnDestroy()
        {
            _playerInput?.Disable();
        }
    }
}