using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public sealed class GameEndUI : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private TMP_Text _killsCountText;
        [SerializeField] private TMP_Text _lvlCountText;
        [SerializeField] private TMP_Text _gameOverText;
        
        public Button RestartButton => _restartButton;
        public Button ExitButton => _exitButton;
        public TMP_Text KillsCountText => _killsCountText;
        public TMP_Text LevelCountText => _lvlCountText;
        public TMP_Text GameOverText => _gameOverText;

        private void OnDestroy()
        {
            _restartButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}