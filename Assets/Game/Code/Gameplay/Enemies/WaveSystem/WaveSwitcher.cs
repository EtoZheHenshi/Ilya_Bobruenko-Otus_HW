using System;
using Game.Code.Infrastructure;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;

namespace Game.Code.Gameplay.Enemies.WaveSystem
{
    public sealed class WaveSwitcher : IDisposable
    {
        private readonly AllWavesSO _allWaves;
        private readonly WaveHandler _waveHandler;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly EventBusService _eventBusService;

        private int _waveCount;

        public WaveSwitcher(WaveHandler waveHandler, AllWavesSO allWaves, CoroutineRunner coroutineRunner,
            EventBusService eventBusService)
        {
            _allWaves = allWaves;
            _waveHandler = waveHandler;
            _coroutineRunner = coroutineRunner;
            _eventBusService = eventBusService;
            _waveCount = 0;
            _eventBusService.Subscribe<WaveStartEvent>(SetNextWave);
            
            _waveHandler.OnWaveEndAction = WaveEndAction;
        }

        private void SetNextWave(WaveStartEvent waveStartEvent)
        {
            if (CheckForWave())
            {
                StartWave();
            }
            else
            {
                _eventBusService.Publish(new GameEndEvent());
            }
        }

        private void StartWave()
        {
            _waveHandler.FillWaveEntries(_allWaves.WaveConfigs[_waveCount]);
            _coroutineRunner.Run(_waveHandler.StartWave());
        }

        private bool CheckForWave()
        {
            return _waveCount < _allWaves.WaveConfigs.Length;
        }

        private void WaveEndAction()
        {
            _waveCount++;
            if (CheckForWave())
            {
                _eventBusService.Publish(new WaveFinishEvent(_waveCount + 1));
            }
            else
            {
                _eventBusService.Publish(new GameEndEvent());
            }
        }

        public void Dispose()
        {
            _eventBusService.Unsubscribe<WaveStartEvent>(SetNextWave);
        }
    }
}