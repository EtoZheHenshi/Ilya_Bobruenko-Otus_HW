using UnityEngine;

namespace Game.Code.Gameplay.UI.HUD.HP
{
    public sealed class HpIconModel
    {
        private readonly HpIconView _view;
        
        private bool _isHpEmpty;
        
        public bool IsHpEmpty => _isHpEmpty;
        public Transform Transform => _view.transform;

        public HpIconModel(HpIconView view)
        {
            _view = view;
        }

        public void SetHpFull()
        {
            _view.HpImage.sprite = _view.HpSprite;
            _isHpEmpty = false;
        }

        public void SetHpEmpty()
        {
            _view.HpImage.sprite = _view.HpEmptySprite;
            _isHpEmpty = true;
        }
    }
}