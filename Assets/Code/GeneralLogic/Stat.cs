using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.GeneralLogic
{
    [Serializable]
    public sealed class Stat
    {
        [SerializeField] private float _baseValue;
        [SerializeField] private float _maxValue;
        [SerializeField] private float _minValue;
        
        private readonly List<StatModifier> _modifiers = new();

        public float Value => GetValue();

        public void AddModifier(StatModifier modifier)
        {
            _modifiers.Add(modifier);
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
                else
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