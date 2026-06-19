using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Gameplay.General.Stats
{
    [Serializable]
    public sealed class Stat
    {
        [SerializeField] private float _baseValue;
        [SerializeField] private float _minValue;
        [SerializeField] private float _maxValue;

        private readonly List<StatModifier> _modifiers;
        
        public float CurrentValue => GetValue();
        public float BaseValue => _baseValue;
        public float MinValue => _minValue;
        public float MaxValue => _maxValue;

        public Stat()
        {
            _modifiers = new List<StatModifier>();
        }

        public Stat(Stat stat) : this()
        {
            _baseValue = stat.BaseValue;
            _minValue = stat.MinValue;
            _maxValue = stat.MaxValue;
        }

        public void AddModifier(StatModifier modifier)
        {
            _modifiers.Add(modifier);
        }

        public void ClearModifiers()
        {
            _modifiers.Clear();
        }

        private float GetValue()
        {
            float flatSum = 0f;
            float percentSum = 0f;

            for (int i = 0; i < _modifiers.Count; i++)
            {
                if (_modifiers[i].Type == StatModifierType.Flat)
                {
                    flatSum += _modifiers[i].Value;
                }
                else if (_modifiers[i].Type == StatModifierType.Percent)
                {
                    percentSum += _modifiers[i].Value;
                }
            }
            
            float result = (_baseValue + flatSum) * (1 + percentSum);

            if (result >= _maxValue)
            {
                return _maxValue;
            }

            if (result <= _minValue)
            {
                return _minValue;
            }
            
            return result;
        }
    }
}