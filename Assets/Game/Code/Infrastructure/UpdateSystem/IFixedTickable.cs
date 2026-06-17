namespace Game.Code.Infrastructure.UpdateSystem
{
    public interface IFixedTickable
    {
        public void FixedTick(float fixedDeltaTime);
    }
}