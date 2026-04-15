using Audio;
using InputLogic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public sealed class DeadZone : MonoBehaviour
    {
        [SerializeField] public SoundData gameOverSound;
        
        public void GameOver()
        {
            AudioManager.Instance.PlaySound(gameOverSound);
            InputManager.Instance.GameplayInput.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}