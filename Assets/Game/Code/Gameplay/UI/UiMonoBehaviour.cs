using System;
using UnityEngine;

namespace Game.Code.Gameplay.UI
{
    public abstract class UiMonoBehaviour : MonoBehaviour
    {
        public event Action OnDestroyEvent;
        public event Action OnEnableEvent;
        public event Action OnDisableEvent;

        private void OnEnable()
        {
            OnEnableEvent?.Invoke();
        }

        private void OnDisable()
        {
            OnDisableEvent?.Invoke();
        }

        private void OnDestroy()
        {
            OnDestroyEvent?.Invoke();
        }
    }
}