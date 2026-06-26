using System;
using Game.Code.Gameplay.Player;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;

namespace Game.Code.Gameplay.UI.HUD.Level
{
    public sealed class LevelTextModel : IDisposable
    {
        private readonly LevelTextView _view;
        private readonly EventBusService _eventBusService;
        private readonly PlayerRegistry _playerRegistry;

        public LevelTextModel(LevelTextView view, EventBusService eventBusService,
            PlayerRegistry playerRegistry)
        {
            _view = view;
            _eventBusService = eventBusService;
            _playerRegistry = playerRegistry;

            _eventBusService.Subscribe<PlayerLevelUpEvent>(PlayerLevelUpAction);
        }

        public void Initialize()
        {
            int startLevel = _playerRegistry.Player.PlayerLevel.CurrentLevel;
            UpdateLevelText(startLevel);
        }

        private void UpdateLevelText(int level)
        {
            _view.LevelCountText.text = level.ToString();
        }
        
        private void PlayerLevelUpAction(PlayerLevelUpEvent @event)
        {
             UpdateLevelText(@event.PlayerNewLevel);
        }

        public void Dispose()
        {
            _eventBusService.Unsubscribe<PlayerLevelUpEvent>(PlayerLevelUpAction);
        }
    }
}