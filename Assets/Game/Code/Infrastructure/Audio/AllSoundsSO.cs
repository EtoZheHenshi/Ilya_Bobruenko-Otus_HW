using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Infrastructure.Audio
{
    [CreateAssetMenu(fileName = "AllSounds", menuName = "SO/Audio/All Sounds")]
    public sealed class AllSoundsSO : ScriptableObject
    {
        [SerializeField] private List<SoundConfigSO> _sounds;
        
        public List<SoundConfigSO> Sounds => _sounds;
    }
}