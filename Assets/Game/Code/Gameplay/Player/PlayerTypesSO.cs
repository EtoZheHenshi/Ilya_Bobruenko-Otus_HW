using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Gameplay.Player
{
    [CreateAssetMenu(fileName = "PlayerTypes", menuName = "SO/Player/Player Types")]
    public sealed class PlayerTypesSO : ScriptableObject
    {
        [SerializeField] private List<PlayerType> _playerTypes;
        
        public List<PlayerType> PlayerTypes => _playerTypes;
    }
}