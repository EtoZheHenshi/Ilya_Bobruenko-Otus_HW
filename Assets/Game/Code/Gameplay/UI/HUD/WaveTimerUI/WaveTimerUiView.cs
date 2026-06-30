using TMPro;
using UnityEngine;

namespace Game.Code.Gameplay.UI.HUD.WaveTimerUI
{
    public sealed class WaveTimerUiView : UiMonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;
        
        public TMP_Text TimerText => _timerText;
    }
}