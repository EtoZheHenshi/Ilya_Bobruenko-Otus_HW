using System;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;
using Game.Code.Infrastructure.GameStateSystem;
using Game.Code.Infrastructure.Input;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Game.Code.Gameplay.UI.PauseWnd
{
    public sealed class PauseWndModel : IDisposable
    {
        private readonly PauseWndView _view;
        private readonly GameStateService _gameStateService;
        private readonly IInputService _inputService;
        private readonly EventBusService _eventBusService;

        public PauseWndModel(PauseWndView view, GameStateService gameStateService, IInputService inputService,
            EventBusService eventBusService)
        {
            _view = view;
            _gameStateService = gameStateService;
            _inputService = inputService;
            _eventBusService = eventBusService;

            _view.ResumeBtn.onClick.AddListener(Resume);
            _view.RestartBtn.onClick.AddListener(Restart);
            _view.MainMenuBtn.onClick.AddListener(MainMenu);
            
            _inputService.PlayerInput.Gameplay.Pause.started += GameplayOnPauseListener;
            _inputService.PlayerInput.Pause.Close.started += PauseOnCloseListener;
            
            _eventBusService.Subscribe<ApplicationFocusLostEvent>(ApplicationFocusLostListener);
        }

        private void Resume()
        {
            Hide();
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        private void Show()
        {
            _gameStateService.SwitchGameState(GameStateType.Pause);
            _view.gameObject.SetActive(true);
        }

        private void Hide()
        {
            _view.gameObject.SetActive(false);
            _gameStateService.SwitchGameState(GameStateType.Gameplay);
        }

        private void GameplayOnPauseListener(InputAction.CallbackContext ctx)
        {
            Show();
        }
        
        private void PauseOnCloseListener(InputAction.CallbackContext ctx)
        {
            Hide();
        }

        private void ApplicationFocusLostListener(ApplicationFocusLostEvent @event)
        {
            if (_gameStateService.CurrentGameState != GameStateType.Gameplay)
            {
                return;
            }
            
            Show();
        }

        public void Dispose()
        {
            _view.ResumeBtn.onClick.RemoveListener(Resume);
            _view.RestartBtn.onClick.RemoveListener(Restart);
            _view.MainMenuBtn.onClick.RemoveListener(MainMenu);
            
            _inputService.PlayerInput.Gameplay.Pause.started -= GameplayOnPauseListener;
            _inputService.PlayerInput.Pause.Close.started -= PauseOnCloseListener;
            
            _eventBusService.Unsubscribe<ApplicationFocusLostEvent>(ApplicationFocusLostListener);
        }
    }
}