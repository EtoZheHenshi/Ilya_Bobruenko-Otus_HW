using System;
using Code.GameLogic;
using Code.UI.UpgradeMenu;
using Code.Upgrades;
using UnityEngine;

namespace Code.UI
{
    public sealed class UIController : IDisposable
    {
        private readonly StartLevelUI _startLevelUI;
        private readonly UpgradeMenuModel _upgradeMenuModel;
        
        public event Action OnStartLevel
        {
            add => _startLevelUI.OnStart += value;
            remove => _startLevelUI.OnStart -= value;
        }

        public UIController(StartLevelUI startLevelUI, UpgradeMenuView upgradeMenuView, UpgradeManager upgradeManager)
        {
            _startLevelUI = startLevelUI;
            
            _upgradeMenuModel = new UpgradeMenuModel(upgradeMenuView, upgradeManager);
            _upgradeMenuModel.OnHide += SwitchGameStateToGameplay;
        }

        public void StartLevel()
        {
            _startLevelUI.RefreshTimer();
            _startLevelUI.Show();
            _startLevelUI.StartTimer();
        }

        public void ShowUpgradeMenu()
        {
            GameState.SwitchGameState(GameStateType.UpgradeMenu);
            _upgradeMenuModel.UpdateCards();
            _upgradeMenuModel.Show();
        }

        public void SwitchGameStateToGameplay()
        {
            GameState.SwitchGameState(GameStateType.Gameplay);
        }

        public void Dispose()
        {
            _upgradeMenuModel.OnHide -= SwitchGameStateToGameplay;
        }
    }
}