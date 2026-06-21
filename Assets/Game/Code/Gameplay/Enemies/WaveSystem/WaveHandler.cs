using System.Collections;
using System.Collections.Generic;
using Game.Code.Gameplay.Enemies.SpawnerSystem;
using Game.Code.Infrastructure;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;
using UnityEngine;

namespace Game.Code.Gameplay.Enemies.WaveSystem
{
    public sealed class WaveHandler
    {
        private readonly CoroutineRunner _coroutineRunner;
        private readonly EventBusService _eventBusService;
        private readonly EnemySpawnerSystem _enemySpawnerSystem;
        private readonly Dictionary<WaveEntry, List<EnemySpawner>> _waveEntries;
        private int _countOfAllEnemiesInWaves;

        public WaveHandler(CoroutineRunner coroutineRunner, EventBusService eventBusService,
            EnemySpawnerSystem enemySpawnerSystem)
        {
            _coroutineRunner = coroutineRunner;
            _eventBusService = eventBusService;
            _enemySpawnerSystem = enemySpawnerSystem;
            _waveEntries = new Dictionary<WaveEntry, List<EnemySpawner>>();
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
                _coroutineRunner.Run(StartWaveEntry(waveEntry.Key, waveEntry.Value));
            }

            yield return new WaitUntil(() => _countOfAllEnemiesInWaves == 0);
            
            _eventBusService.Publish(new WaveFinishEvent());
        }

        private IEnumerator StartWaveEntry(WaveEntry waveEntry, List<EnemySpawner> supportedSpawners)
        {
            yield return new WaitForSeconds(waveEntry.TimeToStartWave);

            for (int i = 0; i < waveEntry.Count; i++)
            {
                EnemyFacade enemy = supportedSpawners[Random.Range(0, supportedSpawners.Count)]
                    .Spawn(waveEntry.EnemyConfigSO);
                enemy.EnemyHealth.OnDeath += HandleEnemyDeath;
                
                yield return new WaitForSeconds(waveEntry.SpawnInterval);
            }
        }

        private void HandleEnemyDeath()
        {
            _countOfAllEnemiesInWaves--;
        }
    }
}