using System;
using Code.Input.MapsControllers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Input
{
    public sealed class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }
        
        public GameplayInputController Gameplay { get; private set; }
        public MainMenuInputController MainMenu { get; private set; }
        public PauseMenuInputController PauseMenu { get; private set; }
        public UpgradeMenuController UpgradeMenu { get; private set; }
        
        private PlayerInput _playerInput;
        private InputActionMap _currentMap;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }

        public bool Initialize()
        {
            try
            {
                _playerInput = new PlayerInput();
                _playerInput.Enable();
            
                Gameplay = new GameplayInputController(_playerInput.Gameplay);
                MainMenu = new MainMenuInputController(_playerInput.MainMenu);
                PauseMenu = new PauseMenuInputController(_playerInput.PauseMenu);
                UpgradeMenu = new UpgradeMenuController(_playerInput.UpgradeMenu);

                foreach (InputActionMap map in _playerInput.asset.actionMaps)
                {
                    map.Disable();
                }
                
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Ошибка инициализации InputManager - {e.Message}");
                return false;
            }
        }

        public void SwitchActiveMap(string mapName)
        {
            _currentMap?.Disable();
            
            _currentMap = _playerInput.asset.FindActionMap(mapName);
            _currentMap.Enable();
        }

        public void DisableActiveMap()
        {
            _currentMap?.Disable();
        }

        // private void OnEnable()
        // {
        //     _playerInput.Enable();
        // }
        //
        // private void OnDisable()
        // {
        //     _playerInput.Disable();
        // }
    }
}