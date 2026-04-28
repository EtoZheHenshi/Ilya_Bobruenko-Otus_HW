using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public sealed class AudioLibraryUI  : MonoBehaviour
    {
        [SerializeField] private AudioLibraryFile[] audioLibrary;
        
        public static AudioLibraryUI Instance { get; private set; }
        public Dictionary<string, SoundData> Library => _library;

        private Dictionary<string, SoundData> _library;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            FillLibrary();
        }
        
        private void FillLibrary()
        {
            _library = new Dictionary<string, SoundData>();

            for (int i = 0; i < audioLibrary.Length; i++)
            {
                _library.Add(audioLibrary[i].Name, audioLibrary[i].Sound);
            }
        }
    }
}