using System;
using Code.Upgrades;
using TMPro;
using UnityEngine.Events;

namespace Code.UI.UpgradeMenu
{
    public sealed class UpgradeCardModel
    {
        public event Action OnApplyEvent;
        
        private readonly TMP_Text _title;
        private readonly TMP_Text _description;
        
        private UnityAction _applyUpgrade;

        public UpgradeCardModel(UpgradeCardView upgradeCardView)
        {
            _title = upgradeCardView.TitleText;
            _description = upgradeCardView.DescriptionText;

            upgradeCardView.OnClick.AddListener(ApplyUpgrade);

            upgradeCardView.OnDestroyEvent += () =>
            {
                upgradeCardView.OnClick.RemoveListener(ApplyUpgrade);
                OnApplyEvent = null;
            };
        }

        public void SetUpgrade(UpgradeSO upgrade)
        {
            _title.text = upgrade.Title;
            _description.text = upgrade.Description;
            _applyUpgrade = upgrade.Apply;
        }

        private void ApplyUpgrade()
        {
            _applyUpgrade?.Invoke();
            OnApplyEvent?.Invoke();
        }
    }
}