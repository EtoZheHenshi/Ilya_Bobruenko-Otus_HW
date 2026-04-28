using Audio;
using DG.Tweening;
using Gameplay;
using InputLogic;
using Tween;
using UnityEngine;

namespace UI
{
    public sealed class EndLevelMenu : MonoBehaviour
    {
        [SerializeField] private WinWindow winWindow;
        [SerializeField] private LoseWindow loseWindow;
        [SerializeField] private Transform bricks;
        [SerializeField] private FadeCanvasGroup windowShowAnimation;
        
        [Header("Sounds")]
        [SerializeField] public SoundData gameOverSound;
        [SerializeField] public SoundData winningSound;

        private void Start()
        {
            LevelData.OnLevelEnd += Show;
            gameObject.SetActive(false);
        }

        private void Show()
        {
            windowShowAnimation.GetSequence().Play();
            InputManager.Instance.GameplayInput.Disable();
            
            if (LevelData.LevelWin)
            {
                AudioManager.Instance.PlaySound(winningSound);
                winWindow.Show();
            }
            else
            {
                AudioManager.Instance.PlaySound(gameOverSound);
                loseWindow.Show();
            }
            
            gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            LevelData.OnLevelEnd -= Show;
        }
    }
}