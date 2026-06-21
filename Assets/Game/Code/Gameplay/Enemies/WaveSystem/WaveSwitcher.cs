using Game.Code.Infrastructure;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;

namespace Game.Code.Gameplay.Enemies.WaveSystem
{
    public sealed class WaveSwitcher
    {
        private readonly AllWavesSO _allWaves;
        private readonly WaveHandler _waveHandler;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly EventBusService _eventBusService;

        private int _waveCount;
        private bool _canStartWave;

        public WaveSwitcher(WaveHandler waveHandler, AllWavesSO allWaves, CoroutineRunner coroutineRunner,
            EventBusService eventBusService)
        {
            _allWaves = allWaves;
            _waveHandler = waveHandler;
            _coroutineRunner = coroutineRunner;
            _eventBusService = eventBusService;
            _waveCount = -1;
            _eventBusService.Subscribe<WaveStartEvent>(SetNextWave);
        }

        private void SetNextWave(WaveStartEvent waveStartEvent)
        {
            _waveCount++;
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
    }
}