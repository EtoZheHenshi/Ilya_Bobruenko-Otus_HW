using System;
using InputLogic;
using UnityEngine;

namespace Gameplay
{
    public sealed class Paddle : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed;
        
        public float Width {get; private set;}

        private float _direction;

        private void Start()
        {
            InputManager.Instance.GameplayInput.Move += ctx =>
            {
                _direction = ctx.ReadValue<Vector2>().x;
            };
            
            Width = transform.localScale.x;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            float x = _direction * speed;
            rb.linearVelocity = new Vector3(x, 0, 0);
        }
    }
}