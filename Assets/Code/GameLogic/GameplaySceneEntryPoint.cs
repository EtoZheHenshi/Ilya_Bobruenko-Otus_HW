using Code.Guns;
using Code.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.GameLogic
{
    public class GameplaySceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private PlayerGunSelector playerGunSelector;
        
        private void Start()
        {
            if (!Bootstrap.IsInitialized)
            {
                Bootstrap.NextSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Bootstrap");
                return;
            }
            
            playerController.Initialize();
            playerGunSelector.Initialize();
            
            GameState.SwitchGameState(GameStateType.Gameplay);
        }
    }
}