using Code.GeneralLogic;
using UnityEngine;

namespace Code.Enemies
{
    public abstract class EnemyStatsSO : ScriptableObject
    {
        [SerializeField] private Stat _maxHealth;
        [SerializeField] private Stat _moveSpeed;
        [SerializeField] private Stat _touchDamage;
        [SerializeField] private float _touchDamageDelay;
        
        public Stat MaxHealth => _maxHealth;
        public Stat MoveSpeed => _moveSpeed;
        public Stat TouchDamage => _touchDamage;
        public float TouchDamageDelay => _touchDamageDelay;
    }
}