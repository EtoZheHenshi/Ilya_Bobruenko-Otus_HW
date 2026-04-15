using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "Audio/Sound Data")]
    public sealed class SoundData : ScriptableObject
    {
        [SerializeField] private AudioClip[] clips;
        [SerializeField] private bool isPitchRandom;
        [SerializeField] private float pitchVariance = 0.1f;
        
        [Range(0f, 1f)] public float volume = 1f;
        [Range(0.5f, 2f)] public float pitch = 1f;
        
        public AudioClip GetClip()
        {
            return clips[Random.Range(0, clips.Length)];
        }

        public float GetPitch()
        {
            if (isPitchRandom)
            {
                return pitch + Random.Range(-pitchVariance, pitchVariance);
            }
            
            return pitch;
        }
    }
}