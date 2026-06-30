using System;
using Game.Code.Infrastructure;
using Game.Code.Infrastructure.Audio;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;
using UnityEngine;

namespace Game.Code.Gameplay.Enemies.WaveSystem
{
    public sealed class WaveSwitcher : IDisposable
    {
        private readonly AllWavesSO _allWaves;
        private readonly WaveHandler _waveHandler;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly EventBusService _eventBusService;
        private readonly WaveTimer _waveTimer;
        private readonly AudioService _audioService;
        private Coroutine _startWaveCoroutine;

        private int _waveCount;

        public WaveSwitcher(WaveHandler waveHandler, AllWavesSO allWaves, CoroutineRunner coroutineRunner,
            EventBusService eventBusService, WaveTimer waveTimer, AudioService audioService)
        {
            _allWaves = allWaves;
            _waveHandler = waveHandler;
            _coroutineRunner = coroutineRunner;
            _eventBusService = eventBusService;
            _waveTimer = waveTimer;
            _audioService = audioService;
            _waveCount = 0;
            _eventBusService.Subscribe<WaveStartEvent>(SetNextWave);
            
            _waveTimer.OnTimerEnd += WaveEndAction;
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
                _eventBusService.Publish(new GameEndEvent(true));
            }
        }

        private void StartWave()
        {
            _waveHandler.FillWaveEntries(_allWaves.WaveConfigs[_waveCount]);
            _waveTimer.StartTimer();
            _startWaveCoroutine = _coroutineRunner.Run(_waveHandler.StartWave());
        }

        private bool CheckForWave()
        {
            return _waveCount < _allWaves.WaveConfigs.Length;
        }

        private void WaveEndAction()
        {
            StopCoroutine();
            
            _waveHandler.ClearWave();
            
            _audioService.Play(SoundId.WaveEnd);
            
            _waveCount++;
            if (CheckForWave())
            {
                _eventBusService.Publish(new WaveFinishEvent(_waveCount + 1));
            }
            else
            {
                _eventBusService.Publish(new GameEndEvent(true));
            }
        }

        private void StopCoroutine()
        {
            if (_coroutineRunner != null)
            {
                _coroutineRunner.Stop(_startWaveCoroutine);
            }
        }

        public void Dispose()
        {
            _eventBusService.Unsubscribe<WaveStartEvent>(SetNextWave);
            _waveTimer.OnTimerEnd -= WaveEndAction;

            StopCoroutine();
        }
    }
}