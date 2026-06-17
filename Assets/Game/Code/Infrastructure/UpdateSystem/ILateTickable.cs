namespace Game.Code.Infrastructure.UpdateSystem
{
    public interface ILateTickable
    {
        public void LateTick(float deltaTime);
    }
}