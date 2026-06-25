using UnityEngine;
using Zenject;

namespace Game.Code.Gameplay.Upgrades
{
    public abstract class BulletEffectUpgradeSO : UpgradeSO
    {
        [SerializeField] private int _maxLevel;
        
        public int MaxLevel => _maxLevel;
    }
}