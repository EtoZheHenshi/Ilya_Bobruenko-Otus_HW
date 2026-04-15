using System;
using Audio;
using InputLogic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public sealed class DeadZone : MonoBehaviour
    {
        [SerializeField] private Transform bricks;
        [SerializeField] public SoundData gameOverSound;
        [SerializeField] public SoundData winningSound;

        private void Update()
        {
            if (bricks.childCount == 0)
            {
                Winning();
            }
        }
        
        public void GameOver()
        {
            AudioManager.Instance.PlaySound(gameOverSound);
            RestartLevel();
        }
        
        private void Winning()
        {
            AudioManager.Instance.PlaySound(winningSound);
            RestartLevel();
        }

        private void RestartLevel()
        {
            InputManager.Instance.GameplayInput.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}