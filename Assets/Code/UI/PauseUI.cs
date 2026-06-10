using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public sealed class PauseUI : MonoBehaviour
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        
        public Button ResumeButton => _resumeButton;
        public Button RestartButton => _restartButton;
        public Button ExitButton => _exitButton;

        private void OnDestroy()
        {
            _resumeButton.onClick.RemoveAllListeners();
            _restartButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}