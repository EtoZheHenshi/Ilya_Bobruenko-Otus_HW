using System.Collections.Generic;
using UnityEngine;

namespace Code.Enemies.WaveSystem
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "Enemy/WaveConfigSO", order = 1)]
    public sealed class WaveConfigSO : ScriptableObject
    {
        [SerializeField] private List<WaveEntry> waveEntries;
        
        public List<WaveEntry> WaveEntries => waveEntries;
    }
}