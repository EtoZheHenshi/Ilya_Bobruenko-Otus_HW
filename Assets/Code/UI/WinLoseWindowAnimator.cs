using DG.Tweening;
using Tween;
using UnityEngine;

namespace UI
{
    public sealed class WinLoseWindowAnimator : MonoBehaviour
    {
        [SerializeField] private FadeCanvasGroup panelShow;
        [SerializeField] private FallFromAbove trophyShow;
        [SerializeField] private FallFromAbove coinShow;
        [SerializeField] private FadeCanvasGroup buttonsFade;
        [SerializeField] private Scale buttonsScale;
        [SerializeField] private FadeCanvasGroup hideWindow;
        
        private Sequence _sequence;

        public Sequence Show()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();

            _sequence.Append(panelShow.GetSequence());
            _sequence.Append(trophyShow.GetSequence());
            _sequence.Append(coinShow.GetSequence());
            _sequence.Append(buttonsFade.GetSequence());
            _sequence.Join(buttonsScale.GetSequence());
            
            _sequence.SetUpdate(true);
            return _sequence;
        }

        public Sequence Hide()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            
            _sequence.Append(hideWindow.GetSequence());
            
            _sequence.SetUpdate(true);
            return _sequence;
        }
    }
}