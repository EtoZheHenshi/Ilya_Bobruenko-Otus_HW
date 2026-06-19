using System;

namespace Game.Code.Gameplay.General.Stats
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