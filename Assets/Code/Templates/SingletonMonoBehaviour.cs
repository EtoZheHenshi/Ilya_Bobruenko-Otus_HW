using UnityEngine;

namespace Code.Templates
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour 
        where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;

            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }
    }
}