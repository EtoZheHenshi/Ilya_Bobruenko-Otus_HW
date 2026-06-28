using UnityEngine;

namespace Game.Code.Infrastructure.Audio
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "SO/Audio/Sound Config")]
    public sealed class SoundConfigSO : ScriptableObject
    {
        [SerializeField] private SoundId _soundId;
        [SerializeField] private AudioClip[] _sounds;
        [SerializeField] private bool _randomPitch;
        [SerializeField] private Vector2 _pitchRange = new (-0.1f, 0.1f);
        
        [Range(0f, 1f)]
        [SerializeField] private float _volume = 1f;
        [Range(0.5f, 2f)]
        [SerializeField] private float _pitch = 1f;
        
        public SoundId SoundId => _soundId;
        public AudioClip[] Sounds => _sounds;
        public bool RandomPitch => _randomPitch;
        public Vector2 PitchRange => _pitchRange;
        public float Volume => _volume;
        public float Pitch => _pitch;
    }
}