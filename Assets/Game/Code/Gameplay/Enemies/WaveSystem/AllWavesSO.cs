using UnityEngine;

namespace Game.Code.Gameplay.Enemies.WaveSystem
{
    [CreateAssetMenu(fileName = "AllWaves", menuName = "SO/Enemies/Waves/All Waves")]
    public sealed class AllWavesSO : ScriptableObject
    {
        [SerializeField] private WaveConfigSO[] _waveConfigs;
        
        public WaveConfigSO[] WaveConfigs => _waveConfigs;
    }
}