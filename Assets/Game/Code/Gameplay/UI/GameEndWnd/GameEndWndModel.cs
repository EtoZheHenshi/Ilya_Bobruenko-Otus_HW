using System;
using Game.Code.Gameplay.General;
using Game.Code.Infrastructure.Audio;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;
using Game.Code.Infrastructure.GameStateSystem;
using UnityEngine.SceneManagement;

namespace Game.Code.Gameplay.UI.GameEndWnd
{
    public sealed class GameEndWndModel : IDisposable
    {
        private readonly GameEndWndView _view;
        private readonly GameStateService _gameStateService;
        private readonly EventBusService _eventBusService;
        private readonly AudioService _audioService;
        private readonly RunStatus _runStatus;

        public GameEndWndModel(GameEndWndView view, GameStateService gameStateService, EventBusService eventBusService,
            AudioService audioService, RunStatus runStatus)
        {
            _view = view;
            _gameStateService = gameStateService;
            _eventBusService = eventBusService;
            _audioService = audioService;
            _runStatus = runStatus;
            _eventBusService.Subscribe<GameEndEvent>(Show);
            
            _view.RestartButton.onClick.AddListener(Restart);
            _view.MainMenuButton.onClick.AddListener(MainMenu);
        }

        private void Show(GameEndEvent gameEndEvent)
        {
            _gameStateService.SwitchGameState(GameStateType.GameEnd);
            _audioService.StopLoop(SoundId.GameplayTheme);
            
            if (gameEndEvent.IsWinning)
            {
                _view.BgImage.sprite = _view.BgWinSprite;
                _view.TitleImage.sprite = _view.WinSprite;
                _view.StatusImage.sprite = _view.WinStatusSprite;
                _audioService.Play(SoundId.WinSound);
            }
            else
            {
                _view.BgImage.sprite = _view.BgLoseSprite;
                _view.TitleImage.sprite = _view.LoseSprite;
                _view.StatusImage.sprite = _view.LoseStatusSprite;
                _audioService.Play(SoundId.LoseSound);
            }
            
            _view.KillsCountText.text = _runStatus.KillsAmount.ToString();
            _view.LevelCountText.text = _runStatus.PlayerLevel.ToString();
            
            _view.gameObject.SetActive(true);
        }
        
        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void Dispose()
        {
            _eventBusService.Unsubscribe<GameEndEvent>(Show);
            
            _view.RestartButton.onClick.RemoveListener(Restart);
            _view.MainMenuButton.onClick.RemoveListener(MainMenu);
        }
    }
}