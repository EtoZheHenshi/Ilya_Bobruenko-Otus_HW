using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Weapons
{
    public class BulletDamageable : MonoBehaviour
    {
        [SerializeField] private GameObject bulletHolePrefab;
        [SerializeField] private float liveTime;
        
        public IEnumerator CreateBulletHole(Vector3 position, Vector3 normal)
        {
            GameObject bulletHole = Instantiate(bulletHolePrefab, position, Quaternion.LookRotation(-normal), transform);
            bulletHole.TryGetComponent<DecalProjector>(out DecalProjector decalProjector);
            // if (decalProjector != null)
            // {
            //     decalProjector.transform.rotation = Quaternion.FromToRotation(Vector3.forward, normal);
            //     Vector3 angles = decalProjector.transform.eulerAngles;
            //     decalProjector.transform.rotation = Quaternion.Euler(angles.x, angles.y, Random.Range(0, 360));
            // }
            
            yield return new WaitForSeconds(liveTime);
            Destroy(bulletHole);
        }
    }
}