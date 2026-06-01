using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Enemies.WaveSystem
{
    public sealed class WaveManager : MonoBehaviour
    {
        public event Action OnWavesFinished;
        
        private readonly Dictionary<WaveEntry, List<EnemySpawner>> _waves = new();
        private int _countOfAllEnemiesInWaves;

        public IEnumerator StartAllWaves()
        {
            foreach (KeyValuePair<WaveEntry, List<EnemySpawner>> wave in _waves)
            {
                StartCoroutine(StartWave(wave.Key, wave.Value));
            }
            
            yield return new WaitUntil(() => _countOfAllEnemiesInWaves == 0);
            
            OnWavesFinished?.Invoke();
        }

        public void FillWaves(WaveConfigSO waveConfig, EnemySpawnerSystem enemySpawnerSystem)
        {
            _waves.Clear();
            _countOfAllEnemiesInWaves = 0;
            
            for (int i = 0; i < waveConfig.WaveEntries.Count; i++)
            {
                List<EnemySpawner> supportedSpawners = enemySpawnerSystem.GetSupportedSpawners(
                    waveConfig.WaveEntries[i].enemyConfig);
                _waves.Add(waveConfig.WaveEntries[i], supportedSpawners);
                
                _countOfAllEnemiesInWaves += waveConfig.WaveEntries[i].count;
            }
        }

        private IEnumerator StartWave(WaveEntry waveEntry, List<EnemySpawner> supportedSpawners)
        {
            yield return new WaitForSeconds(waveEntry.timeToStartWave);
            
            for (int i = 0; i < waveEntry.count; i++)
            {
                Enemy enemy = supportedSpawners[Random.Range(0, supportedSpawners.Count)].Spawn(waveEntry.enemyConfig);
                enemy.HealthSystem.OnDeath += HandleEnemyDeath;
                
                yield return new WaitForSeconds(waveEntry.spawnInterval);
            }
        }

        private void HandleEnemyDeath()
        {
            _countOfAllEnemiesInWaves--;
        }
    }
}