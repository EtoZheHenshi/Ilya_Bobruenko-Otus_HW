using System;
using TMPro;
using UnityEngine;

namespace Code.UI.HUD
{
    public sealed class HUDView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _hpCount;
        [SerializeField] private TMP_Text _lvlCount;

        public event Action OnDeath;
        
        public TMP_Text HpCount => _hpCount;
        public TMP_Text LvlCount => _lvlCount;

        private void OnDestroy()
        {
            OnDeath?.Invoke();
        }
    }
}