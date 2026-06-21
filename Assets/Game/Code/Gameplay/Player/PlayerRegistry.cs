using Game.Code.Gameplay.General;
using UnityEngine;

namespace Game.Code.Gameplay.Player
{
    public sealed class PlayerRegistry
    {
        public PlayerFacade Player {get; private set;}
        
        public Transform Transform => Player.transform;
        public IDamageable Damageable => Player.PlayerHealth;

        public void Register(PlayerFacade player)
        {
            Player = player;
        }
    }
}