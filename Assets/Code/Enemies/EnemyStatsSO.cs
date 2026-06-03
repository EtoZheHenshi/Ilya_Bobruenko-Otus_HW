using Code.GeneralLogic;
using UnityEngine;

namespace Code.Enemies
{
    public abstract class EnemyStatsSO : ScriptableObject
    {
        [SerializeField] private Stat _maxHealth;
        [SerializeField] private Stat _moveSpeed;
        
        public Stat MaxHealth => _maxHealth;
        public Stat MoveSpeed => _moveSpeed;
    }
}