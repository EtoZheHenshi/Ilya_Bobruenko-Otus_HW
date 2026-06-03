using System;

namespace Code.GeneralLogic
{
    [Serializable]
    public struct StatModifier
    {
        public float Value;
        public StatModifierType Type;

        public StatModifier(float value, StatModifierType type)
        {
            Value = value;
            Type = type;
        }
    }
}