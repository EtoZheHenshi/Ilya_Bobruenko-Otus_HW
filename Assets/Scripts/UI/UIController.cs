using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        
        private bool _isPause;

        public bool IsPause => _isPause;

        public void PauseSwitch()
        {
            _isPause = !_isPause;
            pauseMenu.SetActive(_isPause);
            Time.timeScale = _isPause ? 0 : 1;

            if (_isPause)
            {
                ShowCursor();
            }
            else
            {
                HideCursor();
            }
        }
        
        private void ShowCursor()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        private void HideCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}