using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.Gameplay.UI.GameEndWnd
{
    public sealed class GameEndWndView : UiMonoBehaviour
    {
        [SerializeField] private TMP_Text _killsCountText;
        [SerializeField] private TMP_Text _levelCountText;
        [SerializeField] private Image _bgImage;
        [SerializeField] private Sprite _bgLoseSprite;
        [SerializeField] private Sprite _bgWinSprite;
        [SerializeField] private Image _titleImage;
        [SerializeField] private Sprite _loseSprite;
        [SerializeField] private Sprite _winSprite;
        [SerializeField] private Image _statusImage;
        [SerializeField] private Sprite _loseStatusSprite;
        [SerializeField] private Sprite _winStatusSprite;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        
        public TMP_Text KillsCountText => _killsCountText;
        public TMP_Text LevelCountText => _levelCountText;
        public Image BgImage => _bgImage;
        public Sprite BgLoseSprite => _bgLoseSprite;
        public Sprite BgWinSprite => _bgWinSprite;
        public Image TitleImage => _titleImage;
        public Sprite LoseSprite => _loseSprite;
        public Sprite WinSprite => _winSprite;
        public Image StatusImage => _statusImage;
        public Sprite LoseStatusSprite => _loseStatusSprite;
        public Sprite WinStatusSprite => _winStatusSprite;
        public Button RestartButton => _restartButton;
        public Button MainMenuButton => _mainMenuButton;
    }
}