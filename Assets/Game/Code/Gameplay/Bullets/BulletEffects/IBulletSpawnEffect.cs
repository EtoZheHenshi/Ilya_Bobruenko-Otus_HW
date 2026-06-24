namespace Game.Code.Gameplay.Bullets.BulletEffects
{
    public interface IBulletSpawnEffect : IBulletEffect
    {
        public void OnSpawn(Bullet bullet);
    }
}