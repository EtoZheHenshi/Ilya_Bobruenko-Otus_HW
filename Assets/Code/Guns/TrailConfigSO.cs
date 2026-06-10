using UnityEngine;

namespace Code.Guns
{
    [CreateAssetMenu (fileName = "TrailConfig", menuName = "Guns/Gun Trail Config", order = 4)]
    public class TrailConfigSO : ScriptableObject
    {
        public Material Material;
        public AnimationCurve WidthCurve;
        public float Duration = 0.5f;
        public float MinVertexDistance = 0.1f;
        public Gradient Color;
        public float SimulationSpeed = 100f;
        [SerializeField] private GunStatsSO _gunStats;

        public float MissDistance => _gunStats.Distance.Value;
    }
}