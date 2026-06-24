using UnityEngine;

namespace Game.Code.Gameplay.UI.UpgradeMenuWnd
{
    public sealed class UpgradeMenuWndView : UiMonoBehaviour
    {
        [SerializeField] private UpgradeCardView[] _upgradeCardViews;
        
        public UpgradeCardView[] UpgradeCardViews => _upgradeCardViews;
    }
}