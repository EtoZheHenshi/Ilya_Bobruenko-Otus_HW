using UnityEngine;

namespace Game.Code.Gameplay.Upgrades
{
    public abstract class Upgrade
    {
        protected readonly UpgradeSO _upgradeSO;
        
        public string Title => _upgradeSO.Title;
        public string Description => _upgradeSO.Description;

        public Upgrade(UpgradeSO upgradeSO)
        {
            _upgradeSO = upgradeSO;
        }
        
        public abstract void Apply();
        public abstract bool IsAvailable();
    }
}