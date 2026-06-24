namespace Game.Code.Gameplay.Bullets.BulletEffects
{
    public interface IBulletDestroyEffect : IBulletEffect
    {
        public void OnDestroy(Bullet bullet);
    }
}