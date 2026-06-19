namespace Game.Code.Infrastructure.UpdateSystem
{
    public interface IFixedUpdatable
    {
        public void FixedTick(float fixedDeltaTime);
    }
}