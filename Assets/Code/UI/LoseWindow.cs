using Audio;
using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class LoseWindow : MonoBehaviour
    {
        [SerializeField] private Button restartBtn;
        [SerializeField] private TMP_Text coinText;
        [SerializeField] private TMP_Text trophyText;
        [SerializeField] private LoseWindowAnimator animator;

        private void Start()
        {
            restartBtn.onClick.AddListener(Restart);
        }

        public void Show()
        {
            UpdateText();
            gameObject.SetActive(true);
            animator.Show();
        }
        
        private void UpdateText()
        {
            coinText.text = RewardData.FinalCoin.ToString();
            trophyText.text = RewardData.FinalTrophy.ToString();
        }
        
        private void Restart()
        {
            AudioManager.Instance.PlaySound(AudioLibraryUI.Instance.Library["ButtonClick"]);
            RewardData.ResetReward();
            LevelData.RestartLevel();
        }
    }
}