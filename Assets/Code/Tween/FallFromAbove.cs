using System;
using DG.Tweening;
using UnityEngine;

namespace Tween
{
    public class FallFromAbove : MonoBehaviour
    {
        [SerializeField] private TweenParams tweenParams;
        [SerializeField] private RectTransform rectTransform;
        
        private Sequence _sequence;

        private void Start()
        {
            rectTransform.localScale = new Vector3(3f, 3f, 3f);
            gameObject.SetActive(false);
        }

        public Sequence GetSequence()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            
            _sequence.OnStart( () => gameObject.SetActive(true));

            _sequence.Append(rectTransform.DOScale(1.0f, tweenParams.duration)
                .SetEase(tweenParams.easeType)
                .SetDelay(tweenParams.delay));
            _sequence.SetUpdate(true);
            _sequence.Pause();
            
            return _sequence;
        }
    }
}