using System;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;
using Game.Code.Infrastructure.UpdateSystem;

namespace Game.Code.Gameplay.Enemies.WaveSystem
{
    public sealed class WaveTimer : IUpdatable, IDisposable
    {
        private const float StartWaveTime = 180f;

        public event Action OnTickEvent;
        public event Action OnTimerEnd;
        
        private readonly UpdateService _updateService;

        private float _currentWaveTime;
        private bool _timerActive;
        
        public float CurrentWaveTime => _currentWaveTime;

        public WaveTimer(UpdateService updateService)
        {
            _updateService = updateService;
            _updateService.Register(this);
        }
        
        public void Tick(float deltaTime)
        {
            if (!_timerActive) 
                return;
            
            _currentWaveTime -= deltaTime;
            OnTickEvent?.Invoke();

            if (_currentWaveTime < 0)
            {
                _timerActive = false;
                OnTimerEnd?.Invoke();
            }
        }

        public void StartTimer()
        {
            _currentWaveTime = StartWaveTime;
            _timerActive = true;
        }

        public void Dispose()
        {
            _updateService.Unregister(this);
        }
    }
}