using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Gameplay.Enemies.WaveSystem
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "SO/Enemies/Waves/Wave Config")]
    public sealed class WaveConfigSO : ScriptableObject
    {
        [SerializeField] private List<WaveEntry> _waveEntries;
        
        public List<WaveEntry> WaveEntries => _waveEntries;
    }
}