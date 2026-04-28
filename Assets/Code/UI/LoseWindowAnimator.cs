using DG.Tweening;
using Tween;
using UnityEngine;

namespace UI
{
    public sealed class LoseWindowAnimator : MonoBehaviour
    {
        [SerializeField] private FadeCanvasGroup losePanelShow;
        [SerializeField] private FallFromAbove trophyShow;
        [SerializeField] private FallFromAbove coinShow;
        [SerializeField] private FadeCanvasGroup buttonShow;
        
        private Sequence _sequence;

        public void Show()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();

            _sequence.Append(losePanelShow.GetSequence());
            _sequence.Append(trophyShow.GetSequence());
            _sequence.Append(coinShow.GetSequence());
            _sequence.Append(buttonShow.GetSequence());
            
            _sequence.SetUpdate(true);
            _sequence.Play();
        }
    }
}