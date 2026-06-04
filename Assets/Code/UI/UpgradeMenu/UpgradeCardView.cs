using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.UpgradeMenu
{
    public sealed class UpgradeCardView : MonoBehaviour
    {
        [SerializeField] private Button _upgradeBtn;
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _descriptionText;

        public event Action OnDestroyEvent;

        public Button.ButtonClickedEvent OnClick => _upgradeBtn.onClick;

        public TMP_Text TitleText => _titleText;
        public TMP_Text DescriptionText => _descriptionText;

        private void OnDestroy()
        {
            OnDestroyEvent?.Invoke();
        }
    }
}