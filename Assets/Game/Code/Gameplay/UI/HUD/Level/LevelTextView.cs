using TMPro;
using UnityEngine;

namespace Game.Code.Gameplay.UI.HUD.Level
{
    public sealed class LevelTextView : UiMonoBehaviour
    {
        [SerializeField] private TMP_Text _levelCountText;
        
        public TMP_Text LevelCountText => _levelCountText;
    }
}