using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay
{
    public sealed class Paddle : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed;
        
        public float Direction { get; set; }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            float x = Direction * speed * Time.fixedDeltaTime;
            rb.linearVelocity = new Vector3(x, 0, 0);
        }
    }
}