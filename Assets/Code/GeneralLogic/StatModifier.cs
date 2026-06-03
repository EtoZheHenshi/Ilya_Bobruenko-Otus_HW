namespace Code.GeneralLogic
{
    public readonly struct StatModifier
    {
        public readonly float Value;
        public readonly StatModifierType Type;

        public StatModifier(float value, StatModifierType type)
        {
            Value = value;
            Type = type;
        }
    }
}