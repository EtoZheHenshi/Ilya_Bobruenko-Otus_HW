using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public sealed class StartLevelUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;
        
        public event Action OnStart;
        
        private readonly float _maxTime = 3f;
        private bool _timerStarted;
        private float _currentTime;

        private void Update()
        {
            if (!_timerStarted) return;
            
            UpdateTimerText();
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0f)
            {
                _timerStarted = false;
                StartCoroutine(StartRoutine());
            }
        }

        public void RefreshTimer()
        {
            _timerStarted = false;
            _currentTime = _maxTime;
            UpdateTimerText();
        }

        public void StartTimer()
        {
            _timerStarted = true;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator StartRoutine()
        {
            timerText.text = "START";
            yield return new WaitForSeconds(1f);
            Hide();
            OnStart?.Invoke();
        }

        private void UpdateTimerText()
        {
            timerText.text = Mathf.Ceil(_currentTime).ToString();
        }
    }
}