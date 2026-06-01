using System;
using Code.Enemies;
using Code.Enemies.WaveSystem;
using Code.Templates;
using UnityEngine;

namespace Code.GameLogic
{
    public sealed class LevelManager : SingletonMonoBehaviour<LevelManager>
    {
        [SerializeField] private WaveConfigSO[] _levelsWaveConfig;
        [SerializeField] private EnemySpawnerSystem _enemySpawnerSystem;
        
        private bool _isInitialized;
        private WaveManager _waveManager;
        private int _levelCount = 0;

        public void Initialize(WaveManager waveManager)
        {
            _waveManager = waveManager;
            _waveManager.OnWavesFinished += SetNextLevel;
            _isInitialized = true;
        }
        
        public void StartLevel()
        {
            _waveManager.FillWaves(_levelsWaveConfig[_levelCount], _enemySpawnerSystem);
            StartCoroutine(_waveManager.StartAllWaves());
        }

        private void SetNextLevel()
        {
            _levelCount++;
        }

        private void OnDestroy()
        {
            if (!_isInitialized) return;
            _waveManager.OnWavesFinished -= SetNextLevel;
        }
    }
}