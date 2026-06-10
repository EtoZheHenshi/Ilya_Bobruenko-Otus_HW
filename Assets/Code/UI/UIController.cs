using System;
using System.Collections;
using Code.GameLogic;
using Code.Input;
using Code.PlayerLogic;
using Code.UI.HUD;
using Code.UI.UpgradeMenu;
using Code.Upgrades;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.UI
{
    public sealed class UIController : IDisposable
    {
        private readonly StartLevelUI _startLevelUI;
        private readonly UpgradeMenuModel _upgradeMenuModel;
        private readonly LevelCountUI _levelCountUI;
        private readonly HUDModel _hudModel;
        private readonly GameEndUI _gameEndUI;
        private readonly PauseUI _pauseUI;
        
        public event Action OnStartLevel
        {
            add => _startLevelUI.OnStart += value;
            remove => _startLevelUI.OnStart -= value;
        }

        public UIController(StartLevelUI startLevelUI, UpgradeMenuView upgradeMenuView, UpgradeManager upgradeManager,
            LevelCountUI levelCountUI, HUDView hudView, Player player, GameEndUI gameEndUI, PauseUI pauseUI)
        {
            _startLevelUI = startLevelUI;
            
            _upgradeMenuModel = new UpgradeMenuModel(upgradeMenuView, upgradeManager);
            _upgradeMenuModel.OnHide += SwitchGameStateToGameplay;
            
            _levelCountUI = levelCountUI;
            
            _hudModel = new HUDModel(hudView, player);
            
            _gameEndUI = gameEndUI;
            _gameEndUI.RestartButton.onClick.AddListener(GameSceneManager.RestartScene);
            _gameEndUI.ExitButton.onClick.AddListener(GameSceneManager.ExitGame);
            
            _pauseUI = pauseUI;
            _pauseUI.ResumeButton.onClick.AddListener(HidePauseMenu);
            _pauseUI.RestartButton.onClick.AddListener(GameSceneManager.RestartScene);
            _pauseUI.ExitButton.onClick.AddListener(GameSceneManager.ExitGame);
            
            InputManager.Instance.Gameplay.OnPause += GameplayOnPauseListener;
            InputManager.Instance.PauseMenu.OnCloseMenu += PauseMenuOnCloseMenuListener;
        }

        public IEnumerator StartLevel()
        {
            yield return _levelCountUI.ShowWnd($"Level {LevelManager.Instance.LevelCount + 1}");
            
            _startLevelUI.RefreshTimer();
            _startLevelUI.Show();
            _startLevelUI.StartTimer();
        }

        public IEnumerator EndLevel()
        {
            yield return _levelCountUI.ShowWnd("Level Complete");

            yield return new WaitForSeconds(1f);
        }

        public void ShowUpgradeMenu()
        {
            GameState.SwitchGameState(GameStateType.UpgradeMenu);
            _upgradeMenuModel.UpdateCards();
            _upgradeMenuModel.Show();
        }

        public void ShowGameOverMenu()
        {
            GameState.SwitchGameState(GameStateType.OtherMenu);
            if (Player.Instance.IsDead)
            {
                _gameEndUI.GameOverText.text = "YOU DIED";
                _gameEndUI.GameOverText.color = new Color(142, 0, 0);
            }
            else
            {
                _gameEndUI.GameOverText.text = "YOU WIN";
                _gameEndUI.GameOverText.color = new Color(0, 23, 166);
            }
            _gameEndUI.KillsCountText.text = Player.Instance.KilledEnemies.ToString();
            _gameEndUI.LevelCountText.text = Player.Instance.CurrentLvl.ToString();
            
            _gameEndUI.gameObject.SetActive(true);
        }

        private void ShowPauseMenu()
        {
            GameState.SwitchGameState(GameStateType.PauseMenu);
            _pauseUI.gameObject.SetActive(true);
        }

        private void HidePauseMenu()
        {
            GameState.SwitchGameState(GameStateType.Gameplay);
            _pauseUI.gameObject.SetActive(false);
        }

        private void GameplayOnPauseListener(InputAction.CallbackContext ctx)
        {
            ShowPauseMenu();
        }

        private void PauseMenuOnCloseMenuListener(InputAction.CallbackContext ctx)
        {
            HidePauseMenu();
        }

        private void SwitchGameStateToGameplay()
        {
            GameState.SwitchGameState(GameStateType.Gameplay);
        }

        public void Dispose()
        {
            _upgradeMenuModel.OnHide -= SwitchGameStateToGameplay;
            
            InputManager.Instance.Gameplay.OnPause -= GameplayOnPauseListener;
            InputManager.Instance.PauseMenu.OnCloseMenu -= PauseMenuOnCloseMenuListener;
        }
    }
}