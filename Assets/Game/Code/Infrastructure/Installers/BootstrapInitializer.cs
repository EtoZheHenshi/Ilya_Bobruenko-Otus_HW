using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class BootstrapInitializer : IInitializable
    {
        private static int _nextSceneIndex = 1;
        private static bool _isInitialized;
        
        public void Initialize()
        {
            _isInitialized = true;
            
            SceneManager.LoadScene(_nextSceneIndex);

            Debug.Log($"{this.GetType()} initialized");
        }
        
        public static bool CheckBootstrapStatus(Scene activeScene)
        {
            if (_isInitialized) return true;
            
            _nextSceneIndex = activeScene.buildIndex;
            SceneManager.LoadScene(0);
            return false;
        }
    }
}