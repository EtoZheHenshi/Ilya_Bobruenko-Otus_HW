using System;
using UnityEngine;

namespace Game.Code.Gameplay.Player
{
    [Serializable]
    public sealed class PlayerType
    {
        public string Name;
        public GameObject PlayerPrefab;
    }
}