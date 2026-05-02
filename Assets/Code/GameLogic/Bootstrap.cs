using System;
using UnityEngine;

namespace Code.GameLogic
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            GameState.SwitchGameState(GameStateType.Gameplay);
        }
    }
}