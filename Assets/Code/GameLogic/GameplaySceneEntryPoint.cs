using Code.Enemies;
using Code.Guns;
using Code.PlayerLogic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.GameLogic
{
    public class GameplaySceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private EnemySpawnerSystem enemySpawnerSystem;
        
        private void Start()
        {
            if (!Bootstrap.IsInitialized)
            {
                Bootstrap.NextSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Bootstrap");
                return;
            }

            Player.Instance.Initialize();
            enemySpawnerSystem.Initialize();
            
            GameState.SwitchGameState(GameStateType.Gameplay);
        }
    }
}