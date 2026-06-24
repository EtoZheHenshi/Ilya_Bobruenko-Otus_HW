using System;
using System.Collections.Generic;
using Game.Code.Gameplay.Upgrades;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;
using Game.Code.Infrastructure.GameStateSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Code.Gameplay.UI.UpgradeMenuWnd
{
    public sealed class UpgradeMenuWndModel : IDisposable
    {
        private readonly UpgradeMenuWndView _view;
        private readonly AllUpgrades _allUpgrades;
        private readonly GameStateService _gameStateService;
        private readonly EventBusService _eventBusService;
        private UpgradeCardModel[] _upgradeCards;

        private int _pendingLevelUps;

        public UpgradeMenuWndModel(UpgradeMenuWndView view, AllUpgrades allUpgrades, GameStateService gameStateService,
            EventBusService eventBusService)
        {
            _view = view;
            _allUpgrades = allUpgrades;
            _gameStateService = gameStateService;
            _eventBusService = eventBusService;
            
            _eventBusService.Subscribe<PlayerLevelUpEvent>(GetUpgrades);

            CreateUpgradeCards();
        }

        public void GetUpgrades(PlayerLevelUpEvent playerLevelUpEvent)
        {
            _pendingLevelUps++;

            if (_view.gameObject.activeSelf)
            {
                return;
            }

            ShowNextUpgrade();
        }

        private void ShowNextUpgrade()
        {
            List<Upgrade> availableUpgrades = _allUpgrades.GetAvailableUpgrades();
            int amount = availableUpgrades.Count > 3 ? 3 : availableUpgrades.Count;

            for (int i = 0; i < amount; i++)
            {
                Upgrade upgrade = availableUpgrades[Random.Range(0, availableUpgrades.Count)];
                availableUpgrades.Remove(upgrade);
                _upgradeCards[i].SetUpgradeInfo(upgrade);
                _upgradeCards[i].Show();
            }
            
            Show();
        }

        private void Show()
        {
            _gameStateService.SwitchGameState(GameStateType.Upgrade);
            _view.gameObject.SetActive(true);
        }

        private void Hide()
        {
            HideUpgradeCards();

            _pendingLevelUps--;

            if (_pendingLevelUps > 0)
            {
                ShowNextUpgrade();
                return;
            }

            _view.gameObject.SetActive(false);
            _gameStateService.SwitchGameState(GameStateType.Gameplay);
        }

        private void HideUpgradeCards()
        {
            for (int i = 0; i < _upgradeCards.Length; i++)
            {
                _upgradeCards[i].Hide();
            }
        }

        private void CreateUpgradeCards()
        {
            _upgradeCards = new UpgradeCardModel[_view.UpgradeCardViews.Length];
            for (int i = 0; i < _view.UpgradeCardViews.Length; i++)
            {
                UpgradeCardModel card = new UpgradeCardModel(_view.UpgradeCardViews[i]);
                card.OnClick.AddListener(Hide);
                _upgradeCards[i] = card;
            }
        }

        public void Dispose()
        {
            _eventBusService.Unsubscribe<PlayerLevelUpEvent>(GetUpgrades);
        }
    }
}