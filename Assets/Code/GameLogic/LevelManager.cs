using System;
using Code.Enemies;
using Code.Enemies.SpawnerSystem;
using Code.Enemies.WaveSystem;
using Code.Templates;
using UnityEngine;

namespace Code.GameLogic
{
    public sealed class LevelManager : SingletonMonoBehaviour<LevelManager>
    {
        [SerializeField] private WaveConfigSO[] _levelsWaveConfig;
        [SerializeField] private EnemySpawnerSystem _enemySpawnerSystem;
        
        public event Action OnGameEnd;
        
        private WaveManager _waveManager;
        private int _levelCount = 0;
        private bool _canStartLevel = false;
        
        public int LevelCount => _levelCount;

        public void Initialize(WaveManager waveManager)
        {
            _waveManager = waveManager;
            CheckNextLevel();
        }
        
        public void StartLevel()
        {
            if (!_canStartLevel) return;
            _waveManager.FillWaves(_levelsWaveConfig[_levelCount], _enemySpawnerSystem);
            StartCoroutine(_waveManager.StartAllWaves());
        }

        public bool SetNextLevel()
        {
            _levelCount++;
            CheckNextLevel();
            return _canStartLevel;
        }

        public void EndGame()
        {
            OnGameEnd?.Invoke();
        }

        private void CheckNextLevel()
        {
            if (_levelCount < _levelsWaveConfig.Length)
            {
                _canStartLevel = true;
            }
            else
            {
                _canStartLevel = false;
            }
        }
    }
}