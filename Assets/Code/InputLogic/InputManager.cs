using Gameplay;
using UnityEngine;

namespace InputLogic
{
    public sealed class InputManager : MonoBehaviour
    {
        [SerializeField] private Paddle paddle;
        
        public static InputManager Instance { get; private set; }
        public PlayerInput PlayerInput { get; private set; }
        public GameplayInputController GameplayInput { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            PlayerInput = new PlayerInput();
            PlayerInput.Enable();
            
            GameplayInput = new GameplayInputController(PlayerInput, paddle);
            GameplayInput.Enable();
        }

        private void OnDestroy()
        {
            PlayerInput.Disable();
        }
    }
}