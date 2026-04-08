using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData weaponData;
        [SerializeField] private Transform bulletLaunchPosition;
        
        public bool IsShooting { get; set; }
        public bool IsReloading  { get; set; }

        public int Ammo => weaponData.MaxBulletInMagazine - _currentBulletInMagazine + 1;
        public string WeaponName => weaponName;

        protected string weaponName = "defaultName";

        private Bullet[] _magazine;
        private int _currentBulletInMagazine = -1;
        private GameObject _magazineRoot;
        private float _nextShootTime;

        protected virtual void Start()
        {
            _magazine = new Bullet[weaponData.MaxBulletInMagazine];
            
            if (_magazineRoot == null)
            {
                _magazineRoot = new GameObject("Magazine");
                _magazineRoot.transform.SetParent(transform);
            }
            
            Reload();
            IsReloading = false;
        }

        private void Update()
        {
            if (IsReloading || !IsShooting) return;

            if (Time.time >= _nextShootTime)
            {
                Shoot();
            }
        }

        public void Shoot()
        {
                if (_currentBulletInMagazine <= weaponData.MaxBulletInMagazine)
                {
                    Bullet currentBullet = _magazine[_currentBulletInMagazine - 1];
                    _currentBulletInMagazine++;

                    Ray ray = Camera.main!.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                    if (Physics.Raycast(ray, out RaycastHit hit, 100f))
                    {
                        currentBullet.Launch(bulletLaunchPosition, hit.point, weaponData.BulletSpeed);
                        if (hit.transform.TryGetComponent(out BulletDamageable damageable))
                        {
                            StartCoroutine(damageable.CreateBulletHole(currentBullet, hit.point, hit.normal));
                        }
                    }
                    else
                    {
                        Vector3 targetPoint = ray.origin + ray.direction * 100f;
                        currentBullet.Launch(bulletLaunchPosition, targetPoint, weaponData.BulletSpeed);
                    }
                    
                    _nextShootTime = Time.time + weaponData.DelayBeetweenShots;
                }
        }

        public void Reload()
        {
            IsReloading = true;
            if (_currentBulletInMagazine < _magazine.Length || _currentBulletInMagazine > _magazine.Length)
            {
                _currentBulletInMagazine = _magazine.Length;
            }

            for (int i = _currentBulletInMagazine; i > 0; i--)
            {
                Bullet newBullet = Instantiate(weaponData.Bullet, _magazineRoot.transform);
                newBullet.gameObject.SetActive(false);
                _magazine[i - 1] = newBullet;
            }
            
            _currentBulletInMagazine = 1;
        }
    }
}