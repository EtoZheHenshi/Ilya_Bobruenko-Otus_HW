using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.Gameplay.UI.PauseWnd
{
    public sealed class PauseWndView : UiMonoBehaviour
    {
        [SerializeField] private Button _resumeBtn;
        [SerializeField] private Button _restartBtn;
        [SerializeField] private Button _mainMenuBtn;
        
        public Button ResumeBtn => _resumeBtn;
        public Button RestartBtn => _restartBtn;
        public Button MainMenuBtn => _mainMenuBtn;
    }
}