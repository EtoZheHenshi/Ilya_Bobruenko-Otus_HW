using System;

namespace Game.Code.Gameplay.Enemies.WaveSystem
{
    [Serializable]
    public sealed class WaveEntry
    {
        public EnemyConfigSO EnemyConfigSO;
        public int Count;
        public float SpawnInterval;
        public float TimeToStartWave;
    }
}