using Game.Code.Gameplay.General.Stats;
using UnityEngine;

namespace Game.Code.Gameplay.Upgrades
{
    public abstract class StatUpgrade : Upgrade
    {
        public StatModifier StatModifier => ((StatUpgradeSO)_upgradeSO).StatModifier;
        public abstract Stat Stat { get; }
        
        public StatUpgrade(StatUpgradeSO statUpgradeSO) : base(statUpgradeSO)
        {
        }

        public override void Apply()
        {
            Stat.AddModifier(StatModifier);
        }

        public override bool IsAvailable()
        {
            return Stat.CurrentValue < Stat.MaxValue && Stat.CurrentValue > Stat.MinValue;
        }
    }
}