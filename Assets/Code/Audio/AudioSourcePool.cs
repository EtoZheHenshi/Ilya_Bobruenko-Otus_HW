using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public sealed class AudioSourcePool : MonoBehaviour
    {
        [SerializeField] private int audioSourceCount;

        private Queue<AudioSource> _audioSources;
        private int _extraCount;

        private void Awake()
        {
            _audioSources = new Queue<AudioSource>(audioSourceCount);
            
            CreateSources();
        }

        private void CreateSources()
        {
            if (_audioSources != null && _audioSources.Count > 0)
            {
                for (int i = 0; i < _audioSources.Count; i++)
                {
                    _audioSources.Enqueue(CreateOneSource($"AudioSource_{i}"));
                }
            }
        }

        public AudioSource GetAudioSource()
        {
            if (_audioSources.Count > 0)
            {
                return _audioSources.Dequeue();
            }
            else
            {
                return CreateOneSource($"AudioSource_Extra_{_extraCount++}");
            }
        }

        public void ReturnAudioSource(AudioSource source)
        {
            source.Stop();
            _audioSources.Enqueue(source);
        }

        private AudioSource CreateOneSource(string sourceName)
        {
            GameObject obj = new GameObject(sourceName);
            obj.transform.SetParent(transform);
            AudioSource source = obj.AddComponent<AudioSource>();
            source.playOnAwake = false;
                    
            return source;
        }
    }
}