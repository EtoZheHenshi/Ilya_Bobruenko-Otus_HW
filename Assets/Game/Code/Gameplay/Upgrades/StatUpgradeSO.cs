using System;
using Game.Code.Gameplay.General.Stats;
using UnityEngine;

namespace Game.Code.Gameplay.Upgrades
{
    public abstract class StatUpgradeSO : UpgradeSO
    {
        [SerializeField] private StatModifier _statModifier;
        
        public StatModifier StatModifier => _statModifier;
        public override string Description => String.Format(_description, GetValue());

        private float GetValue()
        {
            if (_statModifier.Type == StatModifierType.Percent)
            {
                return Mathf.Abs(_statModifier.Value) * 100f;
            }

            return _statModifier.Value;
        }
    }
}