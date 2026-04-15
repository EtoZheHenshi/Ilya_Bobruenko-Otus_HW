using System;
using System.Collections;
using UnityEngine;

namespace Audio
{
    public sealed class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSourcePool pool;
        
        public static AudioManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void PlaySound(SoundData soundData, Vector3 position)
        {
            AudioSource source = pool.GetAudioSource();
            
            source.clip = soundData.GetClip();
            source.transform.position = position;
            source.pitch = soundData.GetPitch();
            source.volume = soundData.volume;
            
            source.Play();
            
            StartCoroutine(ReturnToPool(source));
        }

        private IEnumerator ReturnToPool(AudioSource source)
        {
            yield return new WaitForSeconds(source.clip.length);
            pool.ReturnAudioSource(source);
        }
    }
}