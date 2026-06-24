namespace Game.Code.Gameplay.Bullets.BulletEffects
{
    public interface IBulletHitEffect : IBulletEffect
    {
        public void OnHit(Bullet bullet);
    }
}