using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoseWindow : MonoBehaviour
    {
        [SerializeField] private Button restartBtn;
        [SerializeField] private TMP_Text coinText;
        [SerializeField] private TMP_Text trophyText;

        private void Start()
        {
            restartBtn.onClick.AddListener(Restart);
        }

        public void Show()
        {
            UpdateText();
            gameObject.SetActive(true);
        }
        
        private void UpdateText()
        {
            coinText.text = RewardData.FinalCoin.ToString();
            trophyText.text = RewardData.FinalTrophy.ToString();
        }
        
        private void Restart()
        {
            RewardData.ResetReward();
            LevelData.RestartLevel();
        }
    }
}