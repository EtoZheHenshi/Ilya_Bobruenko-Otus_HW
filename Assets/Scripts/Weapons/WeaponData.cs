using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Data/SO/WeaponData")]
    public sealed class WeaponData : ScriptableObject
    {
        [SerializeField] private int weaponID;
        [SerializeField] private string weaponName;
        [SerializeField] private Bullet bullet;
        [SerializeField] private int maxBulletInMagazine;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float delayBeetweenShots;

        public int WeaponID => weaponID;
        public string WeaponName => weaponName;
        public Bullet Bullet => bullet;
        public int MaxBulletInMagazine => maxBulletInMagazine;
        public float BulletSpeed => bulletSpeed;
        public float DelayBeetweenShots => delayBeetweenShots;
    }
}