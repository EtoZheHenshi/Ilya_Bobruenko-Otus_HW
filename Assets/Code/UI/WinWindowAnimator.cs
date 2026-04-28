using DG.Tweening;
using Tween;
using UnityEngine;

namespace UI
{
    public sealed class WinWindowAnimator : MonoBehaviour
    {
        [SerializeField] private FadeCanvasGroup winPanelShow;
        [SerializeField] private FallFromAbove trophyShow;
        [SerializeField] private FallFromAbove coinShow;
        [SerializeField] private FadeCanvasGroup buttonsShow;
        
        private Sequence _sequence;

        public void Show()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();

            _sequence.Append(winPanelShow.GetSequence());
            _sequence.Append(trophyShow.GetSequence());
            _sequence.Append(coinShow.GetSequence());
            _sequence.Append(buttonsShow.GetSequence());
            
            _sequence.SetUpdate(true);
            _sequence.Play();
        }
    }
}