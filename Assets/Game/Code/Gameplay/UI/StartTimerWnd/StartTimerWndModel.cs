using System;
using System.Collections;
using Game.Code.Infrastructure.EventBusSystem;
using Game.Code.Infrastructure.EventBusSystem.Events;
using Game.Code.Infrastructure.UpdateSystem;
using UnityEngine;

namespace Game.Code.Gameplay.UI.StartTimerWnd
{
    public sealed class StartTimerWndModel : IUpdatable, IDisposable
    {
        private const float MaxTime = 3f;
        
        private readonly StartTimerWndView _view;
        private readonly EventBusService _eventBusService;
        private readonly UpdateService _updateService;

        private bool _timerStarted;
        private float _currentTime;

        public StartTimerWndModel(StartTimerWndView view, EventBusService eventBusService, UpdateService updateService)
        {
            _view = view;
            _eventBusService = eventBusService;
            _updateService = updateService;
            
            _view.OnEnableEvent += OnEnable;
            _view.OnDisableEvent += OnDisable;
            _view.OnDestroyEvent += Dispose;
        }

        public void Tick(float deltaTime)
        {
            if (!_timerStarted) return;
            
            UpdateTimerText();
            _currentTime -= deltaTime;

            if (_currentTime <= 0f)
            {
                _timerStarted = false;
                _view.StartCoroutine(Start());
            }
        }

        private void OnEnable()
        {
            _updateService.Register(this);
        }

        private void OnDisable()
        {
            _updateService.Unregister(this);
        }

        public void StartTimer()
        {
            _currentTime = MaxTime;
            UpdateTimerText();
            Show();
            _timerStarted = true;
        }

        public void Show()
        {
            _view.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _view.gameObject.SetActive(false);
        }

        private IEnumerator Start()
        {
            _view.StartTimerText.text = "START";
            yield return new WaitForSeconds(1f);
            Hide();
            _eventBusService.Publish(new WaveStartEvent());
        }
        
        private void UpdateTimerText()
        {
            _view.StartTimerText.text = Mathf.Ceil(_currentTime).ToString();
        }
        
        public void Dispose()
        {
            _view.OnEnableEvent -= OnEnable;
            _view.OnDisableEvent -= OnDisable;
            _view.OnDestroyEvent -= Dispose;
        }
    }
}