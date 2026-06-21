using Game.Code.Gameplay.General.Stats;
using UnityEngine;

namespace Game.Code.Gameplay.Enemies
{
    public abstract class EnemyStatsSO : ScriptableObject
    {
        [SerializeField] private Stat _maxHealth;
        [SerializeField] private Stat _speed;
        
        public Stat MaxHealth => _maxHealth;
        public Stat Speed => _speed;
    }
}