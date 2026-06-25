namespace Game.Code.Gameplay.Bullets.BulletEffects
{
    public interface IBulletEffect : IPrioritizedEffect
    {
        public IBulletEffect Clone();
    }
}