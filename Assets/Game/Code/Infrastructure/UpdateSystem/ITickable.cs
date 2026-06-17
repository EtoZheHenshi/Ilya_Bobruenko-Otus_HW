namespace Game.Code.Infrastructure.UpdateSystem
{
    public interface ITickable
    {
        public void Tick(float deltaTime);
    }
}