using System;
using UnityEngine;

namespace Audio
{
    [Serializable]
    public class AudioLibraryFile
    {
        [SerializeField] private string name;
        [SerializeField] private SoundData sound;
        
        public string Name => name;
        public SoundData Sound => sound;
    }
}