using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.Gameplay.UI.MainMenu
{
    public sealed class MainMenuWndView : UiMonoBehaviour
    {
        [SerializeField] private Button _startGameBtn;  
        [SerializeField] private Button _exitBtn;
        
        public Button StartGameBtn => _startGameBtn;
        public Button ExitBtn => _exitBtn;
    }
}