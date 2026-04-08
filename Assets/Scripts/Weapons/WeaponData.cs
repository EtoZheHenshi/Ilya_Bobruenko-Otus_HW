using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Data/SO/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private Bullet bullet;
        [SerializeField] private int maxBulletInMagazine;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float delayBeetweenShots;
        
        public Bullet Bullet => bullet;
        public int MaxBulletInMagazine => maxBulletInMagazine;
        public float BulletSpeed => bulletSpeed;
        public float DelayBeetweenShots => delayBeetweenShots;
    }
}