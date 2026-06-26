using UnityEngine;

namespace Game.Code.Gameplay.UI.HUD.HP
{
    public sealed class HpGroupView : UiMonoBehaviour
    {
        [SerializeField] private HpIconView _hpIconPrefab;
        
        public HpIconView HpIconPrefab => _hpIconPrefab;
    }
}