using UnityEngine;

namespace Game.Code.Gameplay.Enemies
{
    public sealed class EnemiesRoot
    {
        public Transform Transform { get; private set; }

        public EnemiesRoot(Transform transform)
        {
            Transform = transform;
        }
    }
}