using System;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;

namespace Game.Code.Gameplay.General
{
    public sealed class RunStatus : IDisposable
    {
        private readonly EventBusService _eventBusService;
        
        private int _killsAmount;
        private int _playerLevel = 1;
        
        public int KillsAmount => _killsAmount;
        public int PlayerLevel => _playerLevel;

        public RunStatus(EventBusService eventBusService)
        {
            _eventBusService = eventBusService;
            _eventBusService.Subscribe<PlayerLevelUpEvent>(AddPlayerLevel);
        }

        public void AddKill()
        {
            _killsAmount++;
        }

        private void AddPlayerLevel(PlayerLevelUpEvent playerLevelUpEvent)
        {
            _playerLevel++;
        }

        public void Dispose()
        {
            _eventBusService.Unsubscribe<PlayerLevelUpEvent>(AddPlayerLevel);
        }
    }
}