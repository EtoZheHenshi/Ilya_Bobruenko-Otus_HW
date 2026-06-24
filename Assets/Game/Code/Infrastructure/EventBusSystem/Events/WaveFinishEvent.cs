namespace Game.Code.Infrastructure.EventBusSystem.Events
{
    public sealed class WaveFinishEvent : IEvent
    {
        public int NextWaveNumber { get; private set; }

        public WaveFinishEvent(int nextWaveNumber)
        {
            NextWaveNumber = nextWaveNumber;
        }
    }
}