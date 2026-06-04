using System;
using Code.Enemies.WaveSystem;
using Code.PlayerLogic;
using Code.UI;
using Code.UI.UpgradeMenu;
using Code.Upgrades;
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
        [SerializeField] private UpgradeMenuView _upgradeMenuView;
        
        [Header("Data")]
        [SerializeField] private AllUpgradesSO _allUpgrades;
        
        private UpgradeManager _upgradeManager;
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

            _upgradeManager = new UpgradeManager(_allUpgrades);
            
            _uiController = new UIController(_startLevelUI, _upgradeMenuView, _upgradeManager);
            _uiController.OnStartLevel += _levelManager.StartLevel;
            Player.Instance.OnLvlUp += _uiController.ShowUpgradeMenu;
            
            GameState.SwitchGameState(GameStateType.Gameplay);

            _uiController.StartLevel();
        }

        private void OnDestroy()
        {
            if (!Bootstrap.IsInitialized) return;
            //_waveManager.OnWavesFinished += () => Debug.Log("Level Finished");
            _uiController.OnStartLevel -= _levelManager.StartLevel;
            Player.Instance.OnLvlUp -= _uiController.ShowUpgradeMenu;
        }
    }
}