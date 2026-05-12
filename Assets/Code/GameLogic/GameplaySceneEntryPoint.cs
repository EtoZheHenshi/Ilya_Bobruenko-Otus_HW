using Code.Enemies.WaveSystem;
using Code.PlayerLogic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.GameLogic
{
    public class GameplaySceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private WaveManager _waveManager;
        
        private void Start()
        {
            if (!Bootstrap.IsInitialized)
            {
                Bootstrap.NextSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Bootstrap");
                return;
            }

            Player.Instance.Initialize();
            _waveManager.Initialize();
            _waveManager.OnWavesFinished += () => Debug.Log("Level Finished");
            
            GameState.SwitchGameState(GameStateType.Gameplay);

            StartCoroutine(_waveManager.StartAllWaves());
        }
    }
}