using System.Collections;
using GameSubLogic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Weapons
{
    public class BulletDamageable : MonoBehaviour
    {
        [SerializeField] private Decal bulletHolePrefab;
        [SerializeField] private float liveTime;
        
        public IEnumerator CreateBulletHole(Bullet bullet, Vector3 position, Vector3 normal)
        {
            yield return new WaitUntil(() => bullet == null);
            Decal bulletHole = Instantiate(bulletHolePrefab, position, Quaternion.LookRotation(-normal), transform);
            bulletHole.TryGetComponent<DecalProjector>(out DecalProjector decalProjector);
            
            DecalLimiter.AddDecal(bulletHole);
        }
    }
}