using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class BootstrapInitializer : IInitializable
    {
        private const int NextSceneIndex = 1;
        
        public void Initialize()
        {
#if UNITY_EDITOR
            string startupScene =
                UnityEditor.EditorPrefs.GetString(
                    "StartupScene",
                    string.Empty);

            if (!string.IsNullOrEmpty(startupScene) &&
                startupScene != SceneManager.GetActiveScene().path)
            {
                SceneManager.LoadScene(startupScene);
                return;
            }
#endif
            
            SceneManager.LoadScene(NextSceneIndex);

            Debug.Log($"{this.GetType()} initialized");
        }
    }
}