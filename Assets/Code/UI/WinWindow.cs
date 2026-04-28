using System.Linq;
using Audio;
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
            AudioManager.Instance.PlaySound(AudioLibraryUI.Instance.Library["ButtonClick"]);
            Debug.Log("Здесь будет реклама");
        }

        private void Collect()
        {
            AudioManager.Instance.PlaySound(AudioLibraryUI.Instance.Library["ButtonClick"]);
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