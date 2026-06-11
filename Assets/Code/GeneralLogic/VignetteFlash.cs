using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Code.GeneralLogic
{
    public sealed class VignetteFlash : MonoBehaviour
    {
        [SerializeField] private Volume _volume;
        
        private Vignette _vignette;
        private Tween _flashTween;

        private void Awake()
        {
            _volume.profile.TryGet(out _vignette);
        }

        public void Flash()
        {
            _flashTween?.Kill();

            _vignette.intensity.value = 0.4f;

            _flashTween = DOTween.To(
                () => _vignette.intensity.value,
                x => _vignette.intensity.value = x,
                0f,
                2f)
                .SetEase(Ease.OutQuad)
                .SetLink(gameObject);
        }
    }
}