using System;
using InputLogic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public sealed class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed;

        private void Start()
        {
            InputManager.Instance.GameplayInput.Start += ctx =>
            {
                StartMove();
            };
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<DeadZone>(out DeadZone deadZone))
            {
                deadZone.GameOver();
            }

            if (other.gameObject.TryGetComponent<Paddle>(out Paddle paddle))
            {
                Vector2 hitPosition = other.contacts[0].point;

                float x = (hitPosition.x - other.transform.position.x) / (paddle.Width / 2);
                
                Vector3 direction = new Vector3(x, 0.5f, 0).normalized;
                
                rb.linearVelocity = direction * speed;
            }
            else
            {
                float x = rb.linearVelocity.x;
                if (Mathf.Abs(x) < 0.2f)
                {
                    x = Mathf.Sign(x == 0 ? Random.Range(-1f, 1f) : x) * 0.2f;
                }
            
                rb.linearVelocity = new Vector3(x, rb.linearVelocity.y, 0).normalized * speed;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.TryGetComponent<Brick>(out Brick brick))
            {
                brick.Die();
            }
            
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }

        public void StartMove()
        {
            transform.parent = transform.parent.parent;
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), 1f, 0).normalized;
            rb.linearVelocity = direction * speed;
        }
    }
}