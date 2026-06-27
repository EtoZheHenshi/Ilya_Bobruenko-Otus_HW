using UnityEngine;

namespace Game.Code.Gameplay.Player.PlayerComponents
{
    public sealed class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int Move = Animator.StringToHash("Move");
        private static readonly int Shoot = Animator.StringToHash("Shoot");
        
        public void SetMove(float value)
        {
            _animator.SetFloat(Move, value);
        }

        public void Shot()
        {
            _animator.SetTrigger(Shoot);
        }
    }
}