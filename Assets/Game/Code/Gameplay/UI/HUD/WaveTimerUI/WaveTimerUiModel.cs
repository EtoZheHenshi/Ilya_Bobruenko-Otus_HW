using System;
using Game.Code.Gameplay.Enemies.WaveSystem;
using UnityEngine;

namespace Game.Code.Gameplay.UI.HUD.WaveTimerUI
{
    public sealed class WaveTimerUiModel : IDisposable
    {
        private readonly WaveTimerUiView _view;
        private readonly WaveTimer _waveTimer;

        public WaveTimerUiModel(WaveTimerUiView view, WaveTimer waveTimer)
        {
            _view = view;
            _waveTimer = waveTimer;
            _waveTimer.OnTickEvent += UpdateTimerText;
        }

        private void UpdateTimerText()
        {
            _view.TimerText.text = Mathf.Ceil(_waveTimer.CurrentWaveTime).ToString();
        }

        public void Dispose()
        {
            _waveTimer.OnTickEvent -= UpdateTimerText;
        }
    }
}