using Code.Guns;
using Code.PlayerLogic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.GameLogic
{
    public class GameplaySceneEntryPoint : MonoBehaviour
    {
        private void Start()
        {
            if (!Bootstrap.IsInitialized)
            {
                Bootstrap.NextSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Bootstrap");
                return;
            }

            Player.Instance.Initialize();
            
            GameState.SwitchGameState(GameStateType.Gameplay);
        }
    }
}