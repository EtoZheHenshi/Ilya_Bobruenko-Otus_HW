using System;
using Audio;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private UIController controller;
        
        [Header("Windows")]
        [SerializeField] private GameObject mainWindow;
        [SerializeField] private GameObject settingsWindow;
        
        [Header("InputElements")]
        [SerializeField] private Button mainResumeBtn;
        [SerializeField] private Button mainSettingsBtn;
        [SerializeField] private Button setBackBtn;
        [SerializeField] private Slider setVolumeSlider;
        
        private AudioMixer _mixer;

        private void Start()
        {
            _mixer = AudioManager.Instance.Mixer;
            _mixer.GetFloat("Volume", out float volume);
            setVolumeSlider.value = volume;
            
            mainResumeBtn.onClick.AddListener(ClosePauseMenu);
            mainSettingsBtn.onClick.AddListener(SwitchSettingsWindow);
            setBackBtn.onClick.AddListener(SwitchSettingsWindow);
            setVolumeSlider.onValueChanged.AddListener(SetVolume);
        }

        private void OnEnable()
        {
            mainWindow.SetActive(true);
            settingsWindow.SetActive(false);
        }

        private void ClosePauseMenu()
        {
            controller.PauseSwitch();
        }

        private void SwitchSettingsWindow()
        {
            settingsWindow.SetActive(!settingsWindow.activeSelf);
            mainWindow.SetActive(!mainWindow.activeSelf);
        }

        private void SetVolume(float volume)
        {
            _mixer.SetFloat("Volume", volume);
        }
    }
}