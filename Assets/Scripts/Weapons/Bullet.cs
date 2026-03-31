using UnityEngine;

namespace Weapons
{
    public class Bullet : MonoBehaviour
    {
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
                    Destroy(gameObject);
                }
            }
        }

        public void Launch(Transform bulletLaunchPosition, Vector3 hitInfoPoint, float speed)
        {
            transform.position = bulletLaunchPosition.position;
            transform.LookAt(hitInfoPoint);
            _targetPosition = hitInfoPoint;
            _speed = speed;
            transform.parent = null;
            gameObject.SetActive(true);
            _isLaunch = true;
        }
    }
}