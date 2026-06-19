using System;
using UnityEngine;

namespace Game.Code.Gameplay.Items
{
    public sealed class ItemsRoot
    {
        public Transform Transform { get; }

        public ItemsRoot(Transform transform)
        {
            Transform = transform;
        }
    }
}