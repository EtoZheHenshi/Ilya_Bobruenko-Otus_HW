using Game.Code.Infrastructure.GameStateSystem;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public sealed class MainMenuSceneInitializer : IInitializable
    {
        private GameStateService _gameStateService;

        [Inject]
        public void Construct(GameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }
        
        public void Initialize()
        {
            _gameStateService.SwitchGameState(GameStateType.MainMenu);
        }
    }
}