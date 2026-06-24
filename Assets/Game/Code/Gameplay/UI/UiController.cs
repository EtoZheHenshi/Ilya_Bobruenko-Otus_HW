using System;
using System.Collections;
using Game.Code.Gameplay.UI.MiddleScreenTextWnd;
using Game.Code.Gameplay.UI.StartTimerWnd;
using Game.Code.Infrastructure;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;
using UnityEngine;

namespace Game.Code.Gameplay.UI
{
    public sealed class UiController : IDisposable
    {
        private EventBusService _eventBusService;
        private readonly CoroutineRunner _coroutineRunner;

        private readonly StartTimerWndModel _startTimer;
        private readonly MiddleScreenTextWndModel _middleScreenText;

        private int _currentWaveNumber;

        public UiController(EventBusService eventBusService, CoroutineRunner coroutineRunner, 
            StartTimerWndModel startTimer, MiddleScreenTextWndModel middleScreenText)
        {
            _eventBusService = eventBusService;
            _coroutineRunner = coroutineRunner;

            _startTimer = startTimer;
            _middleScreenText = middleScreenText;

            _currentWaveNumber = 1;
            _eventBusService.Subscribe<WaveFinishEvent>(WaveFinishAction);
        }

        public IEnumerator PlayStartWaveTimer()
        {
            _middleScreenText.Show($"WAVE {_currentWaveNumber}");
            yield return new WaitForSeconds(1f);
            _middleScreenText.Hide();
            
            _startTimer.StartTimer();
        }

        private void WaveFinishAction(WaveFinishEvent waveFinishEvent)
        {
            _currentWaveNumber = waveFinishEvent.NextWaveNumber;

            _coroutineRunner.Run(StartNextWaveCycle());
        }

        private IEnumerator StartNextWaveCycle()
        {
            _middleScreenText.Show("WAVE COMPLETED");
            yield return new WaitForSeconds(2f);
            _middleScreenText.Hide();

            _coroutineRunner.Run(PlayStartWaveTimer());
        }

        public void Dispose()
        {
            _eventBusService.Unsubscribe<WaveFinishEvent>(WaveFinishAction);
        }
    }
}