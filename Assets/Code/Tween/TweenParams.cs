using System;
using DG.Tweening;

namespace Tween
{
    [Serializable]
    public sealed class TweenParams
    {
        public float duration = 1;
        public float delay = 0;
        public Ease easeType = Ease.Linear;
    }
}