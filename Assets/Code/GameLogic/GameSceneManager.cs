using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.GameLogic
{
    public static class GameSceneManager
    {
        public static void RestartScene()
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public static void ExitGame()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        }
    }
}