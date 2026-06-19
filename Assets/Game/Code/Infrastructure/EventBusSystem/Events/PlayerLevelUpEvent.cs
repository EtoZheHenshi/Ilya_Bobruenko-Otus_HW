namespace Game.Code.Infrastructure.EventBusSystem.Events
{
    public sealed class PlayerLevelUpEvent : IEvent
    {
        public readonly int PlayerNewLevel;

        public PlayerLevelUpEvent(int playerNewLevel)
        {
            PlayerNewLevel = playerNewLevel;
        }
    }
}