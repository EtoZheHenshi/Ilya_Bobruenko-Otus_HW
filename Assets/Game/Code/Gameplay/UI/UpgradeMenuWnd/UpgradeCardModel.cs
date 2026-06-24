using Game.Code.Gameplay.Upgrades;
using UnityEngine.UI;

namespace Game.Code.Gameplay.UI.UpgradeMenuWnd
{
    public sealed class UpgradeCardModel
    {
        private readonly UpgradeCardView _view;
        private Upgrade _currentUpgrade;
        
        public Button.ButtonClickedEvent OnClick => _view.Button.onClick;

        public UpgradeCardModel(UpgradeCardView view)
        {
            _view = view;
        }

        public void SetUpgradeInfo(Upgrade upgrade)
        {
            if (_currentUpgrade != null)
            {
                _view.Button.onClick.RemoveListener(_currentUpgrade.Apply);
            }
            _currentUpgrade = upgrade;
            
            _view.Title.text = upgrade.Title;
            _view.Description.text = upgrade.Description;
            _view.Button.onClick.AddListener(upgrade.Apply);
        }

        public void Show()
        {
            _view.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _view.gameObject.SetActive(false);
        }
    }
}