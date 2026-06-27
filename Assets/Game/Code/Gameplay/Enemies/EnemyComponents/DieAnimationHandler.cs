using System;
using UnityEngine;

namespace Game.Code.Gameplay.Enemies.EnemyComponents
{
    public sealed class DieAnimationHandler : MonoBehaviour
    {
        public event Action OnEnd;

        public void OnDieAnimationEnd()
        {
            OnEnd?.Invoke();
        }
    }
}