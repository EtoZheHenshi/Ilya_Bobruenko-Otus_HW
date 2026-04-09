using System.Collections;
using GameSubLogic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Weapons
{
    public class BulletDamageable : MonoBehaviour
    {
        public Decal CreateBulletHole(Decal decalPrefab, Vector3 position, Vector3 normal)
        {
            Decal bulletHole = Instantiate(decalPrefab, position, Quaternion.LookRotation(-normal), transform);
            bulletHole.gameObject.SetActive(false);
            
            DecalLimiter.AddDecal(bulletHole);

            return bulletHole;
        }
    }
}