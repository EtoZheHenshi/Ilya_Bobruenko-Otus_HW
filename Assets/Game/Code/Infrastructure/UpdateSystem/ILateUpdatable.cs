namespace Game.Code.Infrastructure.UpdateSystem
{
    public interface ILateUpdatable
    {
        public void LateTick(float deltaTime);
    }
}