using UnityEngine;

namespace Code.Upgrades
{
    public sealed class StatUpgradeHandleHelper : MonoBehaviour
    {
        [SerializeField] private StatUpgradeSO _statUpgrade;

        public void Apply()
        {
            _statUpgrade.Apply();
        }
    }
}