using GameSubLogic;
using UnityEngine;

namespace Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Decal damageDecalPrefab;

        private Decal _damageDecal;
        
        private bool _isLaunch = false;
        private Vector3 _targetPosition;
        private float _speed;

        private void Update()
        {
            if (_isLaunch)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
                {
                    Die();
                }
            }
        }

        public void Launch(Transform bulletLaunchPosition, Vector3 hitPoint, float speed)
        {
            transform.position = bulletLaunchPosition.position;
            transform.LookAt(hitPoint);
            _targetPosition = hitPoint;
            _speed = speed;
            transform.parent = null;
            gameObject.SetActive(true);
            _isLaunch = true;
        }

        public void LaunchIntoObject(Transform bulletLaunchPosition, RaycastHit hit, float speed)
        {
            Launch(bulletLaunchPosition, hit.point, speed);
            
            if (hit.transform.TryGetComponent(out BulletDamageable damageable))
            {
                _damageDecal = damageable.CreateBulletHole(damageDecalPrefab, hit.point, hit.normal);
            }
        }

        public void Die()
        {
            if (_damageDecal != null)
            {
                _damageDecal.gameObject.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}