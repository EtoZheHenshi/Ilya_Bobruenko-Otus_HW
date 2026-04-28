using DG.Tweening;
using UnityEngine;

namespace Tween
{
    public class Scale : MonoBehaviour
    {
        [SerializeField] private TweenParams tweenParams;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Vector3 startScale;
        [SerializeField] private Vector3 endScale;
        
        private Sequence _sequence;

        private void Start()
        {
            rectTransform.localScale = startScale;
            gameObject.SetActive(false);
        }

        public Sequence GetSequence()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            
            _sequence.OnStart( () => gameObject.SetActive(true));

            _sequence.Append(rectTransform.DOScale(endScale, tweenParams.duration)
                .SetEase(tweenParams.easeType)
                .SetDelay(tweenParams.delay));
            _sequence.SetUpdate(true);
            _sequence.Pause();
            
            return _sequence;
        }
    }
}