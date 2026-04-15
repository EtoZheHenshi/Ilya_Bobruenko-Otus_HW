using System.Collections;
using UnityEngine;

namespace Audio
{
    public sealed class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSourcePool pool;
        
        public static AudioManager Instance { get; private set; }
        
        private Vector3 _spawnPoint;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            _spawnPoint = Camera.main.transform.position;
        }

        public void PlaySound(SoundData soundData)
        {
            AudioSource source = pool.GetAudioSource();
            
            source.clip = soundData.GetClip();
            source.pitch = soundData.GetPitch();
            source.volume = soundData.volume;

            source.Play();
            
            StartCoroutine(ReturnToPool(source, source.clip.length));
        }

        private IEnumerator ReturnToPool(AudioSource audioSource, float delay)
        {
            yield return new WaitForSeconds(delay);
            pool.ReturnAudioSource(audioSource);
        }
    }
}