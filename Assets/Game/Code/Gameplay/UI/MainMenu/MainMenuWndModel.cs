using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Gameplay.UI.MainMenu
{
    public sealed class MainMenuWndModel : IDisposable
    {
        private readonly MainMenuWndView _view;

        public MainMenuWndModel(MainMenuWndView view)
        {
            _view = view;
            
            _view.StartGameBtn.onClick.AddListener(StartGame);

#if !UNITY_WEBGL
            _view.ExitBtn.onClick.AddListener(Exit);
#else
            _view.ExitBtn.gameObject.SetActive(false);
#endif
        }

        private void StartGame()
        {
            SceneManager.LoadScene("Gameplay");
        }

#if !UNITY_WEBGL
        private void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
#endif

        public void Dispose()
        {
            _view.StartGameBtn.onClick.RemoveListener(StartGame);
            
#if !UNITY_WEBGL
            _view.ExitBtn.onClick.RemoveListener(Exit);
#endif
        }
    }
}