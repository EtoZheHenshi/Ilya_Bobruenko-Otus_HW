using System;
using Code.GeneralLogic;
using UnityEngine;

namespace Code.Upgrades
{
    public abstract class StatUpgradeSO : UpgradeSO
    {
        [SerializeField] private StatModifier _statModifier;
        
        public abstract Stat Stat { get; }
        public StatModifier StatModifier => _statModifier;
        
        public override string Description => string.Format(_description, GetValue());

        public override void Apply()
        {
            Stat.AddModifierSO(_statModifier);
        }

        public override bool IsAvailable()
        {
            return Stat.Value < Stat.MaxValue;
        }

        private float GetValue()
        {
            if (_statModifier.Type == StatModifierType.Percent)
            {
                return _statModifier.Value * 100f;
            }

            return _statModifier.Value;
        }
    }
}