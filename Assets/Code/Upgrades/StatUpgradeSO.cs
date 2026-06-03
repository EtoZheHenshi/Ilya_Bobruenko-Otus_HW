using System;
using Code.GeneralLogic;
using UnityEngine;

namespace Code.Upgrades
{
    public abstract class StatUpgradeSO : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private StatModifier _statModifier;
        
        public abstract Stat Stat { get; }
        public StatModifier StatModifier => _statModifier;

        public string Title => _title;
        public string Description => string.Format(_description, GetValue());

        public virtual void Apply()
        {
            Stat.AddModifierSO(_statModifier);
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