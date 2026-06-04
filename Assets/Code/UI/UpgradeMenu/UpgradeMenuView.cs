using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.UI.UpgradeMenu
{
    public sealed class UpgradeMenuView : MonoBehaviour
    {
        [SerializeField] private List<UpgradeCardView> _upgradeCards;
        
        public event Action OnDestroyEvent;
        
        public List<UpgradeCardView> UpgradeCards => _upgradeCards;

        private void OnDestroy()
        {
            OnDestroyEvent?.Invoke();
        }
    }
}