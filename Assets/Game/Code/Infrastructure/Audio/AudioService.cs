using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Audio
{
    public sealed class AudioService : MonoBehaviour, IInitializable
    {
        [SerializeField] private AllSoundsSO _allSounds;
        [SerializeField] private AudioSourcePool _pool;

        private Transform _spawnPosition;
        private Dictionary<AudioSource, Coroutine> _activeAudioSource;
        private Dictionary<SoundId, AudioSource> _activeLoopAudioSource;

        [Inject]
        public void Construct()
        {
            _activeAudioSource = new Dictionary<AudioSource, Coroutine>();
            _activeLoopAudioSource = new Dictionary<SoundId, AudioSource>();
        }

        public void Initialize()
        {
            DontDestroyOnLoad(gameObject);
            _pool.Initialize();
        }

        public void SetSpawnPosition(Transform spawnPosition)
        {
            _spawnPosition = spawnPosition;
        }

        public void Play(SoundId soundId)
        {
            if (!ConfigAudioSource(soundId, out var source)) return;
            
            source.Play();
            
            Coroutine cor = StartCoroutine(ReturnToPool(source, source.clip.length));
            
            _activeAudioSource.Add(source, cor);
        }

        public void PlayLoop(SoundId soundId)
        {
            if (!ConfigAudioSource(soundId, out var source)) return;
            
            source.loop = true;
            
            _activeLoopAudioSource.Add(soundId, source);
            source.Play();
        }

        public void StopLoop(SoundId soundId)
        {
            if (_activeLoopAudioSource.TryGetValue(soundId, out var source))
            {
                source.Stop();
                _activeLoopAudioSource.Remove(soundId);
                source.loop = false;
                _pool.ReturnAudioSource(source);
            }
        }

        public void StopAll()
        {
            for (int i = 0; i < _activeAudioSource.Count; i++)
            {
                KeyValuePair<AudioSource, Coroutine> pair = _activeAudioSource.ElementAt(i);
                StopCoroutine(pair.Value);
                pair.Key.Stop();
                _activeAudioSource.Remove(pair.Key);
            }

            for (int i = 0; i < _activeLoopAudioSource.Count; i++)
            {
                KeyValuePair<SoundId, AudioSource> pair = _activeLoopAudioSource.ElementAt(i);
                StopLoop(pair.Key);
            }
        }

        private bool ConfigAudioSource(SoundId soundId, out AudioSource source)
        {
            SoundConfigSO sound = _allSounds.Sounds.First(s => s.SoundId == soundId);
            if (sound == null)
            {
                Debug.Log($"Sound {soundId} not found");
                source = null;
                return false;
            }
            
            source = _pool.GetAudioSource();
            
            source.clip = GetClip(sound);
            source.pitch = GetPitch(sound);
            source.volume = sound.Volume;
            return true;
        }

        private IEnumerator ReturnToPool(AudioSource source, float delay)
        {
            yield return new WaitForSeconds(delay);
            _activeAudioSource.Remove(source);
            _pool.ReturnAudioSource(source);
        }
        
        private AudioClip GetClip(SoundConfigSO soundConfig)
        {
            return soundConfig.Sounds[Random.Range(0, soundConfig.Sounds.Length)];
        }

        private float GetPitch(SoundConfigSO soundConfig)
        {
            if (!soundConfig.RandomPitch) return soundConfig.Pitch;
            
            return soundConfig.Pitch + Random.Range(soundConfig.PitchRange.x, -soundConfig.PitchRange.y);
        }
    }
}