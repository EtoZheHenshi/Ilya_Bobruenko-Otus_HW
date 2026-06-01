using Code.Enemies.WaveSystem;
using Code.PlayerLogic;
using Code.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.GameLogic
{
    public class GameplaySceneEntryPoint : MonoBehaviour
    {
        [Header("System")]
        [SerializeField] private WaveManager _waveManager;
        [SerializeField] private LevelManager _levelManager;
        
        [Header("UI")]
        [SerializeField] private StartLevelUI _startLevelUI;
        
        private UIController _uiController;
        
        private void Start()
        {
            if (!Bootstrap.IsInitialized)
            {
                Bootstrap.NextSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Bootstrap");
                return;
            }
            
            Player.Instance.Initialize();
            _waveManager.OnWavesFinished += () => Debug.Log("Level Finished");
            _levelManager.Initialize(_waveManager);
            
            _uiController = new UIController(_startLevelUI);
            _uiController.OnStartLevel += _levelManager.StartLevel;
            
            GameState.SwitchGameState(GameStateType.Gameplay);

            _uiController.StartLevel();
        }
    }
}