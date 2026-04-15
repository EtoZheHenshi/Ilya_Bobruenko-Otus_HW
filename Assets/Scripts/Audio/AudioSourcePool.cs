using System;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public sealed class AudioSourcePool : MonoBehaviour
    {
        [SerializeField] private int poolSize = 50;

        private Queue<AudioSource> _pool;
        private int _extraSourceCount;

        private void Awake()
        {
            _pool = new Queue<AudioSource>(poolSize);
            
            if (_pool != null && poolSize > 0)
            {
                for (int i = 0; i < poolSize; i++)
                {
                    _pool.Enqueue(CreateAudioSource($"AudioSource_{i}"));
                }
            }
        }

        public AudioSource GetAudioSource()
        {
            if (_pool.Count > 0)
            {
                return _pool.Dequeue();
            }
            else
            {
                return CreateAudioSource($"AudioSource_Extra_{_extraSourceCount++}");
            }
        }

        public void ReturnAudioSource(AudioSource source)
        {
            source.Stop();
            _pool.Enqueue(source);
        }

        private AudioSource CreateAudioSource(string sourceName)
        {
            GameObject obj = new GameObject(sourceName);
            obj.transform.parent = transform;
            
            AudioSource source = obj.AddComponent<AudioSource>();
            source.playOnAwake = false;
            
            return source;
        }
    }
}