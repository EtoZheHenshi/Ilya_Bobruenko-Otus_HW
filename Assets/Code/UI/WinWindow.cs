using Audio;
using DG.Tweening;
using Gameplay;
using TMPro;
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
        [SerializeField] private WinLoseWindowAnimator animator;

        private void Start()
        {
            collectBtn.onClick.AddListener(Collect);
            AdsBtn.onClick.AddListener(GetAds);
        }
        
        public void Show()
        {
            UpdateText();
            gameObject.SetActive(true);
            animator.Show().Play();
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
            Sequence seq = animator.Hide().OnComplete(LevelData.NextLevel);
            seq.Play();
        }
        
        private void UpdateText()
        {
            coinText.text = RewardData.CurrentCoin.ToString();
            trophyText.text = LevelData.CurrentLevel.ToString();
        }
    }
}