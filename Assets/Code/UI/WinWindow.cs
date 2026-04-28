using Gameplay;
using TMPro;
using Tween;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class WinWindow : MonoBehaviour
    {
        [SerializeField] private Button collectBtn;
        [SerializeField] private Button AdsBtn;
        [SerializeField] private TMP_Text coinText;
        [SerializeField] private TMP_Text trophyText;
        [SerializeField] private WinWindowAnimator animator;

        private void Start()
        {
            collectBtn.onClick.AddListener(Collect);
            AdsBtn.onClick.AddListener(GetAds);
        }
        
        public void Show()
        {
            UpdateText();
            gameObject.SetActive(true);
            animator.Show();
        }

        private void GetAds()
        {
            Debug.Log("Здесь будет реклама");
        }

        private void Collect()
        {
            RewardData.AddLevelReward();
            LevelData.NextLevel();
        }
        
        private void UpdateText()
        {
            coinText.text = RewardData.CurrentCoin.ToString();
            trophyText.text = LevelData.CurrentLevel.ToString();
        }
    }
}