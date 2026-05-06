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
                    CursorHide();
                    InputManager.Instance.SwitchActiveMap("Gameplay");
                    break;
                }
                case GameStateType.MainMenu:
                {
                    CursorShow();
                    InputManager.Instance.SwitchActiveMap("MainMenu");
                    break;
                }
                case GameStateType.PauseMenu:
                {
                    CursorShow();
                    InputManager.Instance.SwitchActiveMap("PauseMenu");
                    break;
                }
                case GameStateType.UpgradeMenu:
                {
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

        public static void CursorHide()
        {
            Cursor.visible = false;
        }

        public static void CursorShow()
        {
            Cursor.visible = true;
        }
    }
}