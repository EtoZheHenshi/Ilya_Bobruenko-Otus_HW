using System;
using InputLogic;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public static class LevelData
    {
        public static event Action OnLevelEnd;
        public static bool LevelWin => _levelWin;
        public static int CurrentLevel => _currentLevel;
        
        private static bool _levelWin = false;
        private static int _currentLevel = 1;

        public static void Win()
        {
            _levelWin = true;
            OnLevelEnd?.Invoke();
        }

        public static void Lose()
        {
            RewardData.AddCoinToReward();
            OnLevelEnd?.Invoke();
        }

        public static void NextLevel()
        {
            _currentLevel++;
            _levelWin = false;
            RestartLevel();
        }
        
        public static void RestartLevel()
        {
            InputManager.Instance.GameplayInput.Enable();
            InputManager.Instance.GameplayInput.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}