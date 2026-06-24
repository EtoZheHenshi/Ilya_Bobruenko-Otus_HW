namespace Game.Code.Gameplay.Bullets.BulletEffects
{
    public interface IBulletUpdateEffect : IBulletEffect
    {
        public void OnUpdate(Bullet bullet);
    }
}