using UnityEngine;

namespace Code.Upgrades
{
    public abstract class UpgradeSO : ScriptableObject
    {
        [SerializeField] protected string _title;
        [SerializeField] protected string _description;
        
        public virtual string Title => _title;
        public virtual string Description => _description;
        
        public abstract void Apply();
        public abstract bool IsAvailable();
    }
}