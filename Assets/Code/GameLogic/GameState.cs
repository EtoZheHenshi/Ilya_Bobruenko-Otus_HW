using Code.Input;
using UnityEngine;

namespace Code.GameLogic
{
    public static class GameState
    {
        public static GameStateType CurrentGameState { get; private set; }

        static GameState()
        {
            CurrentGameState = GameStateType.None;
        }
        
        public static void SwitchGameState(GameStateType newGameState)
        {
            switch (newGameState)
            {
                case GameStateType.Gameplay:
                {
                    Time.timeScale = 1;
                    CursorHide();
                    InputManager.Instance.SwitchActiveMap("Gameplay");
                    break;
                }
                case GameStateType.MainMenu:
                {
                    Time.timeScale = 0;
                    CursorShow();
                    InputManager.Instance.SwitchActiveMap("MainMenu");
                    break;
                }
                case GameStateType.PauseMenu:
                {
                    Time.timeScale = 0;
                    CursorShow();
                    InputManager.Instance.SwitchActiveMap("PauseMenu");
                    break;
                }
                case GameStateType.UpgradeMenu:
                {
                    Time.timeScale = 0;
                    CursorShow();
                    InputManager.Instance.SwitchActiveMap("UpgradeMenu");
                    break;
                }
                case GameStateType.None:
                {
                    CursorHide();
                    InputManager.Instance.DisableActiveMap();
                    break;
                }
                default:
                {
                    Debug.LogError("Gameplay state not found");
                    break;
                }
            }
            CurrentGameState = newGameState;
        }

        private static void CursorHide()
        {
            Cursor.visible = false;
        }

        private static void CursorShow()
        {
            Cursor.visible = true;
        }
    }
}