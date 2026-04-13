using InputLogic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public sealed class DeadZone : MonoBehaviour
    {
        public void GameOver()
        {
            InputManager.Instance.GameplayInput.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}