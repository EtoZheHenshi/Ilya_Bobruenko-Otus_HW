using TMPro;
using UnityEngine;

namespace Game.Code.Gameplay.UI.MiddleScreenTextWnd
{
    public sealed class MiddleScreenTextWndView : UiMonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        public TMP_Text Text => _text;
    }
}