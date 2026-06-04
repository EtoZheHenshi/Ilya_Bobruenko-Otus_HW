using System;
using System.Collections.Generic;
using Code.Upgrades;

namespace Code.UI.UpgradeMenu
{
    public sealed class UpgradeMenuModel : IDisposable
    {
        public event Action OnHide;
        
        private readonly List<UpgradeCardView> _upgradeCardViews;
        private readonly List<UpgradeCardModel> _upgradeCardModels;
        private readonly UpgradeManager _upgradeManager;
        private readonly UpgradeMenuView _view;

        public UpgradeMenuModel(UpgradeMenuView view, UpgradeManager upgradeManager)
        {
            _view = view;
            _upgradeCardViews = view.UpgradeCards;
            _upgradeManager = upgradeManager;
            
            _upgradeCardModels = new List<UpgradeCardModel>();
            
            InitializeCards();
            
            _view.OnDestroyEvent += Dispose;
        }

        public void UpdateCards()
        {
            List <UpgradeSO> upgrades = _upgradeManager.GetRandomUpgrades(_upgradeCardModels.Count);

            for (int i = 0; i < _upgradeCardModels.Count; i++)
            {
                _upgradeCardModels[i].SetUpgrade(upgrades[i]);
            }
        }

        public void Show()
        {
            _view.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _view.gameObject.SetActive(false);
            OnHide?.Invoke();
        }

        private void InitializeCards()
        {
            for (int i = 0; i < _upgradeCardViews.Count; i++)
            {
                UpgradeCardModel card = new UpgradeCardModel(_upgradeCardViews[i]);
                card.OnApplyEvent += Hide;
                _upgradeCardModels.Add(card);
            }
        }

        public void Dispose()
        {
            OnHide = null;
            for (int i = 0; i < _upgradeCardModels.Count; i++)
            {
                _upgradeCardModels[i].OnApplyEvent -= Hide;
            }
        }
    }
}