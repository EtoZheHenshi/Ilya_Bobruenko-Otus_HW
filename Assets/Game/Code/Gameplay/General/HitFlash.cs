using DG.Tweening;
using UnityEngine;

namespace Game.Code.Gameplay.General
{
    public sealed class HitFlash : MonoBehaviour
    {
        private Renderer[] _renderers;
        private MaterialPropertyBlock _block;

        private Tween _flashTween;
        
        private static readonly int HitStrengthID = Shader.PropertyToID("_HitStrength");

        private void Awake()
        {
            _renderers = GetComponentsInChildren<Renderer>();
            _block = new MaterialPropertyBlock();
        }

        public void Flash()
        {
            _flashTween?.Kill();
            
            _flashTween = DOTween.To(
                    () => 1f,
                    SetFlash,
                    0f,
                    0.15f
                ).
                SetEase(Ease.OutQuad);
        }

        private void SetFlash(float value)
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                _renderers[i].GetPropertyBlock(_block);
                _block.SetFloat(HitStrengthID, value);
                _renderers[i].SetPropertyBlock(_block);
            }
        }

        private void OnDestroy()
        {
            _flashTween?.Kill();
        }
    }
}