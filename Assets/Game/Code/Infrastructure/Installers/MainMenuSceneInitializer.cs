using System;
using Game.Code.Infrastructure.Audio;
using Game.Code.Infrastructure.GameStateSystem;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class MainMenuSceneInitializer : IInitializable, IDisposable
    {
        private GameStateService _gameStateService;
        private AudioService _audioService;

        [Inject]
        public void Construct(GameStateService gameStateService, AudioService audioService)
        {
            _gameStateService = gameStateService;
            _audioService = audioService;
        }
        
        public void Initialize()
        {
            _audioService.SetSpawnPosition(Camera.main.transform);
            _audioService.PlayLoop(SoundId.MainMenuTheme);
            _gameStateService.SwitchGameState(GameStateType.MainMenu);
        }

        public void Dispose()
        {
            _audioService.StopAll();
        }
    }
}