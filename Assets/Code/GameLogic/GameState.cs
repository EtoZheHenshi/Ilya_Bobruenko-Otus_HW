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