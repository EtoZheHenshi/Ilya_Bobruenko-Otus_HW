using UnityEngine;

namespace Game.Code.Gameplay.Bullets
{
    public sealed class BulletsRoot
    {
        public Transform Transform { get; }
        
        public BulletsRoot(Transform transform)
        {
            Transform = transform;
        }
    }
}