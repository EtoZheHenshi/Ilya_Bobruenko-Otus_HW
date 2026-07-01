using System;
using Game.Code.Infrastructure.GameStateSystem;
using Game.Code.Infrastructure.UpdateSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Code.Gameplay.UI.HUD
{
    public sealed class Crosshair : MonoBehaviour, IUpdatable
    {
        [SerializeField] private RectTransform _crosshair;
        private UpdateService _updateService;
        private GameStateService _gameStateService;

        [Inject]
        public void Construct(UpdateService updateService, GameStateService gameStateService)
        {
            _gameStateService = gameStateService;
            _updateService = updateService;
        }
        
        public void Tick(float deltaTime)
        {
            _crosshair.position = Mouse.current.position.ReadValue();
        }

        private void OnEnable()
        {
            _updateService.Register(this);
        }

        private void OnDisable()
        {
            _updateService.Unregister(this);
        }
    }
}