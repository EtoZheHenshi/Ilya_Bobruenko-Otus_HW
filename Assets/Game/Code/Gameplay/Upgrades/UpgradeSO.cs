using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Upgrades
{
    public abstract class UpgradeSO : ScriptableObject
    {
        [SerializeField] protected string _title;
        [SerializeField] protected string _description;
        
        public string Title => _title;
        public virtual string Description => _description;
        
        public abstract Upgrade CreateUpgrade(DiContainer container);
    }
}