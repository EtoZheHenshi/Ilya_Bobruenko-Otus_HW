using System;
using UnityEngine;
using System.Collections;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform bulletLaunchPosition;
        [SerializeField] private Bullet bullet;
        [SerializeField] private int maxBulletInMagazine;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float delayBeetweenShots;
        
        public bool IsShooting { get; set; }

        public int Ammo
        {
            get { return maxBulletInMagazine - _currentBulletInMagazine + 1; }
        }

        private Bullet[] _magazine;
        private int _currentBulletInMagazine = -1;
        private GameObject _magazineRoot;

        private void Start()
        {
            _magazine = new Bullet[maxBulletInMagazine];
            
            if (_magazineRoot == null)
            {
                _magazineRoot = new GameObject("Magazine");
                _magazineRoot.transform.SetParent(transform);
            }
            
            Reload();
        }

        public IEnumerator Shoot()
        {
            while (IsShooting)
            {
                if (_currentBulletInMagazine <= maxBulletInMagazine)
                {
                    Bullet currentBullet = _magazine[_currentBulletInMagazine - 1];
                    _currentBulletInMagazine++;

                    Ray ray = Camera.main!.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                    if (Physics.Raycast(ray, out RaycastHit hit, 100f))
                    {
                        currentBullet.Launch(bulletLaunchPosition, hit.point, bulletSpeed);
                        if (hit.transform.TryGetComponent(out BulletDamageable damageable))
                        {
                            StartCoroutine(damageable.CreateBulletHole(hit.point, hit.normal));
                        }
                    }
                    else
                    {
                        Vector3 targetPoint = ray.origin + ray.direction * 100f;
                        currentBullet.Launch(bulletLaunchPosition, targetPoint, bulletSpeed);
                    }
                }

                yield return new WaitForSeconds(delayBeetweenShots);
            }
        }

        public void Reload()
        {
            if (_currentBulletInMagazine < _magazine.Length || _currentBulletInMagazine > _magazine.Length)
            {
                _currentBulletInMagazine = _magazine.Length;
            }

            for (int i = _currentBulletInMagazine; i > 0; i--)
            {
                Bullet newBullet = Instantiate(bullet, _magazineRoot.transform);
                newBullet.gameObject.SetActive(false);
                _magazine[i - 1] = newBullet;
            }
            
            _currentBulletInMagazine = 1;
        }
    }
}