using System;

namespace Code.Enemies.WaveSystem
{
    [Serializable]
    public sealed class WaveEntry
    {
        public EnemyConfigSO enemyConfig;
        public int count;
        public float spawnInterval;
        public float timeToStartWave;
    }
}