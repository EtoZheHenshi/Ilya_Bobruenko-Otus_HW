using TMPro;
using UnityEngine;

namespace Game.Code.Gameplay.UI.StartTimerWnd
{
    public sealed class StartTimerWndView : UiMonoBehaviour
    {
        [SerializeField] private TMP_Text _startTimerText;
        
        public TMP_Text StartTimerText => _startTimerText;
    }
}