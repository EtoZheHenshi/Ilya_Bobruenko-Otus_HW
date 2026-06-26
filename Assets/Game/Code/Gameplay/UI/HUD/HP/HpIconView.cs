using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.Gameplay.UI.HUD.HP
{
    public sealed class HpIconView : UiMonoBehaviour
    {
        [SerializeField] private Image _hpImage;
        [SerializeField] private Sprite _hpSprite;
        [SerializeField] private Sprite _hpEmptySprite;
        
        public Image HpImage => _hpImage;
        public Sprite HpSprite => _hpSprite;
        public Sprite HpEmptySprite => _hpEmptySprite;
    }
}