namespace Game.Code.Infrastructure.EventBusSystem.Events
{
    public sealed class GameEndEvent : IEvent
    {
        public bool IsWinning { get; private set; }

        public GameEndEvent(bool isWinning)
        {
            IsWinning = isWinning;
        }
    }
}