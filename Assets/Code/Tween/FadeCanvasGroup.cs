using DG.Tweening;
using UnityEngine;

namespace Tween
{
    public sealed class FadeCanvasGroup : MonoBehaviour
    {
        [SerializeField] private TweenParams tweenParams;
        [SerializeField] private float startAlpha;
        [SerializeField] private float endAlpha;
        [SerializeField] private CanvasGroup canvasGroup;
        
        private Sequence _sequence;

        public Sequence GetSequence()
        {
            canvasGroup.alpha = startAlpha;
            
            _sequence?.Kill();
            _sequence = DOTween.Sequence();

            _sequence.Append(canvasGroup.DOFade(endAlpha, tweenParams.duration))
                .SetDelay(tweenParams.delay)
                .SetEase(tweenParams.easeType);
            _sequence.SetUpdate(true);
            _sequence.Pause();
            
            return _sequence;
        }
    }
}