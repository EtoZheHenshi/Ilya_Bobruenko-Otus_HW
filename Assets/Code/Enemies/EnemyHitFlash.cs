using DG.Tweening;
using UnityEngine;

namespace Code.Enemies
{
    public class EnemyHitFlash : MonoBehaviour
    {
        private Renderer[] _renderers;
        private MaterialPropertyBlock _block;
        
        private static readonly int HitStrengthID = Shader.PropertyToID("_HitStrength");

        private void Awake()
        {
            _renderers = GetComponentsInChildren<Renderer>();
            _block = new MaterialPropertyBlock();
        }

        public void Flash()
        {
            DOTween.To(
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
    }
}