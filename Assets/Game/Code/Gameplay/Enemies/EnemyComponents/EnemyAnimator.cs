using System;
using UnityEngine;

namespace Game.Code.Gameplay.Enemies.EnemyComponents
{
    public sealed class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private DieAnimationHandler _dieAnimationHandler;
        
        public event Action OnDieAnimation
        {
            add => _dieAnimationHandler.OnEnd += value;
            remove => _dieAnimationHandler.OnEnd -= value;
        }
        
        private static readonly int Move = Animator.StringToHash("Move");
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int Die = Animator.StringToHash("Die");
        
        public void SetMove(float move)
        {
            _animator.SetFloat(Move, move);
        }

        public void HitAnimation()
        {
            _animator.SetTrigger(Hit);
        }

        public void DieAnimation()
        {
            _animator.SetTrigger(Die);
        }
    }
}