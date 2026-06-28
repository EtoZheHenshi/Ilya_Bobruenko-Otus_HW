using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Infrastructure.Audio
{
    public sealed class AudioSourcePool : MonoBehaviour
    {
        [SerializeField] private int _audioSourceCount;

        private Queue<AudioSource> _audioSources;
        private int _extraCount;

        public void Initialize()
        {
            _audioSources = new Queue<AudioSource>(_audioSourceCount);
            
            CreateSources();
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

        private void CreateSources()
        {
            if (_audioSources != null && _audioSourceCount > 0)
            {
                for (int i = 0; i < _audioSourceCount; i++)
                {
                    _audioSources.Enqueue(CreateOneSource($"AudioSource_{i}"));
                }
            }
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