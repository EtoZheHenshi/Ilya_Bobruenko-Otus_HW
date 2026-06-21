using System.Collections;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure
{
    public sealed class CoroutineRunner : MonoBehaviour
    {
        [Inject]
        public void Construct()
        {
            DontDestroyOnLoad(gameObject);
        }

        public Coroutine Run(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }
    }
}