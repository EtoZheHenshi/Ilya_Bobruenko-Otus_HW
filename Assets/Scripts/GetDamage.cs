using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class GetDamage : MonoBehaviour
    {
        public int hp;
        public int baseDamage;
        public float multiplier;
        void Start()
        {
            int actualDamage = CalculateActualDamage(multiplier);
            Debug.Log($"Космическая сила наносит {actualDamage} урона великому ничто, у которого было {hp.ToString()} хп.");
            hp -= actualDamage;
            Debug.Log($"Теперь у великого ничто {hp} хп.");
        }

        private int CalculateActualDamage(float multiplier)
        {
            return (int)(baseDamage * multiplier);
        }
    }
}