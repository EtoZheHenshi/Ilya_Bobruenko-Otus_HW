using System;
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
            _view.ExitBtn.onClick.AddListener(Exit);
        }

        private void StartGame()
        {
            SceneManager.LoadScene("Gameplay");
        }

        private void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        public void Dispose()
        {
            _view.StartGameBtn.onClick.RemoveListener(StartGame);
            _view.ExitBtn.onClick.RemoveListener(Exit);
        }
    }
}