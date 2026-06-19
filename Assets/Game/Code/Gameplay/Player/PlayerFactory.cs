using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Player
{
    public sealed class PlayerFactory
    {
        private readonly DiContainer _container;
        private readonly List<PlayerType> _playerTypes;
        
        public PlayerFactory(DiContainer container)
        {
            _container = container;
            _playerTypes = Resources.Load<PlayerTypesSO>("PlayerTypesSO").PlayerTypes;
        }

        public void Create(int id, Vector3 position)
        {
            PlayerType player = _playerTypes[id];
            _container.InstantiatePrefab(player.PlayerPrefab, position, Quaternion.identity, null);
        }
    }
}