using InputLogic;
using UnityEngine;
using UnityEngine.InputSystem;

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
            InputManager.Instance.GameplayInput.Move += MoveGameplayInputListener;
            
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

        private void MoveGameplayInputListener(InputAction.CallbackContext ctx)
        {
            _direction = ctx.ReadValue<Vector2>().x;
        }
    }
}