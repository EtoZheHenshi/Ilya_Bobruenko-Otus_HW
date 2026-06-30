using System;
using System.Collections;
using System.Collections.Generic;
using Game.Code.Gameplay.Enemies.SpawnerSystem;
using Game.Code.Gameplay.General;
using Game.Code.Infrastructure;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Code.Gameplay.Enemies.WaveSystem
{
    public sealed class WaveHandler : IDisposable
    {
        public Action OnWaveEndAction;
        
        private readonly CoroutineRunner _coroutineRunner;
        private readonly EnemySpawnerSystem _enemySpawnerSystem;
        private readonly RunStatus _runStatus;
        private readonly Dictionary<WaveEntry, List<EnemySpawner>> _waveEntries;
        private int _countOfAllEnemiesInWaves;
        private readonly List<Coroutine> _coroutines;
        private readonly List<EnemyFacade> _aliveEnemies;

        public WaveHandler(CoroutineRunner coroutineRunner, EnemySpawnerSystem enemySpawnerSystem, RunStatus runStatus)
        {
            _coroutineRunner = coroutineRunner;
            _enemySpawnerSystem = enemySpawnerSystem;
            _runStatus = runStatus;
            _waveEntries = new Dictionary<WaveEntry, List<EnemySpawner>>();
            _coroutines = new List<Coroutine>();
            _aliveEnemies = new List<EnemyFacade>();
        }

        public void FillWaveEntries(WaveConfigSO waveConfig)
        {
            _waveEntries.Clear();
            _countOfAllEnemiesInWaves = 0;

            for (int i = 0; i < waveConfig.WaveEntries.Count; i++)
            {
                List<EnemySpawner> supportedSpawners = _enemySpawnerSystem
                    .GetSupportedSpawners(waveConfig.WaveEntries[i].EnemyConfigSO);
                _waveEntries.Add(waveConfig.WaveEntries[i], supportedSpawners);

                _countOfAllEnemiesInWaves += waveConfig.WaveEntries[i].Count;
            }
        }

        public IEnumerator StartWave()
        {
            foreach (KeyValuePair<WaveEntry, List<EnemySpawner>> waveEntry in _waveEntries)
            {
                Coroutine coroutine = _coroutineRunner.Run(StartWaveEntry(waveEntry.Key, waveEntry.Value));
                _coroutines.Add(coroutine);
            }

            yield return new WaitUntil(() => _countOfAllEnemiesInWaves == 0);
            
            OnWaveEndAction?.Invoke();
        }

        public void ClearWave()
        {
            StopCoroutines();
            
            for (int i = 0; i < _aliveEnemies.Count; i++)
            {
                if (_aliveEnemies[i] != null)
                {
                    _aliveEnemies[i].EnemyHealth.OnDeath -= HandleEnemyDeath;
                    GameObject.Destroy(_aliveEnemies[i].gameObject);
                }
            }
            
            _aliveEnemies.Clear();
        }

        private IEnumerator StartWaveEntry(WaveEntry waveEntry, List<EnemySpawner> supportedSpawners)
        {
            yield return new WaitForSeconds(waveEntry.TimeToStartWave);

            for (int i = 0; i < waveEntry.Count; i++)
            {
                EnemyFacade enemy = supportedSpawners[Random.Range(0, supportedSpawners.Count)]
                    .Spawn(waveEntry.EnemyConfigSO);
                enemy.EnemyHealth.OnDeath += HandleEnemyDeath;
                _aliveEnemies.Add(enemy);
                
                yield return new WaitForSeconds(waveEntry.SpawnInterval);
            }
        }

        private void HandleEnemyDeath()
        {
            _countOfAllEnemiesInWaves--;
            _runStatus.AddKill();
        }

        private void StopCoroutines()
        {
            if (_coroutineRunner != null)
            {
                foreach (Coroutine coroutine in _coroutines)
                {
                    _coroutineRunner.Stop(coroutine);
                }
            }
        }

        public void Dispose()
        {
            StopCoroutines();
        }
    }
}