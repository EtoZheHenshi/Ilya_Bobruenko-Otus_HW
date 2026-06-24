using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.Gameplay.UI.UpgradeMenuWnd
{
    public sealed class UpgradeCardView : UiMonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Button _button;
        
        public TMP_Text Title => _title;
        public TMP_Text Description => _description;
        public Button Button => _button;
    }
}