using Game.Code.Infrastructure.Input;
using UnityEngine;

namespace Game.Code.Infrastructure.GameStateSystem
{
    public sealed class GameStateService
    {
        private static IInputService _inputService;
        
        public GameStateType CurrentGameState { get; private set; }

        public GameStateService(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void SwitchGameState(GameStateType gameState)
        {
            if (CurrentGameState == gameState)
            {
                return;
            }
            
            switch (gameState)
            {
                case GameStateType.MainMenu:
                {
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    _inputService.SetMap("MainMenu");
                    CurrentGameState = GameStateType.MainMenu;
                    break;
                }
                case GameStateType.Gameplay:
                {
                    Time.timeScale = 1;
                    Cursor.visible = false;
                    _inputService.SetMap("Gameplay");
                    CurrentGameState = GameStateType.Gameplay;
                    break;
                }
                case GameStateType.Pause:
                {
                    Time.timeScale = 0;
                    Cursor.visible = false;
                    _inputService.SetMap("Pause");
                    CurrentGameState = GameStateType.Pause;
                    break;
                }
                case GameStateType.Upgrade:
                {
                    Time.timeScale = 0;
                    Cursor.visible = false;
                    _inputService.CurrentMap.Disable();
                    CurrentGameState = GameStateType.Upgrade;
                    break;
                }
                case GameStateType.GameEnd:
                {
                    Time.timeScale = 0;
                    Cursor.visible = false;
                    _inputService.CurrentMap.Disable();
                    CurrentGameState = GameStateType.GameEnd;
                    break;
                }
            }
        }
    }
}