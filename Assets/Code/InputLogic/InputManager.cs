using System;
using UnityEngine;

namespace InputLogic
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }
        public PlayerInput PlayerInput { get; private set; }

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
        }

        private void OnDestroy()
        {
            PlayerInput.Disable();
        }
    }
}