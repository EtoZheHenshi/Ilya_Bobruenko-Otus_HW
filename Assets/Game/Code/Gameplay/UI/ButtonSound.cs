using System;
using Game.Code.Infrastructure.Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Code.Gameplay.UI
{
    public sealed class ButtonSound : MonoBehaviour
    {
        [SerializeField] private SoundConfigSO _buttonClickSound;
        
        private AudioService _audioService;
        private Button _button;

        [Inject]
        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(PlayClickSound);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PlayClickSound);
        }

        private void PlayClickSound()
        {
            _audioService.PlayNotKillable(_buttonClickSound.SoundId);
        }
    }
}