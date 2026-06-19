namespace Game.Code.Infrastructure.UpdateSystem
{
    public interface IUpdatable
    {
        public void Tick(float deltaTime);
    }
}