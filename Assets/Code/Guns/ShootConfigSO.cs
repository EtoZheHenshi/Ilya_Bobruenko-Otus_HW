using UnityEngine;

namespace Code.Guns
{
    [CreateAssetMenu (fileName = "ShootConfig", menuName = "Guns/Shoot Configuration", order = 2)]
    public sealed class ShootConfigSO : ScriptableObject
    {
        public LayerMask HitMask;
        public Vector3 Spread = new Vector3(0.1f, 0.1f, 0.1f);
        public float FireRate = 0.25f;
    }
}