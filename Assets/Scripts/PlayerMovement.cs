using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private Rigidbody rb;

        public Vector3 MoveDirection { get; set; }
        
        private bool _isPhisic;
        
        public Action Move { get; private set; }

        private void Start()
        {
            Move = MoveTransform;
        }

        private void Update()
        {
            Move();
        }

        void MoveTransform()
        {
            transform.Translate(MoveDirection * (speed * Time.deltaTime));
        }

        void MovePhisic()
        {
            rb.AddForce(MoveDirection * (speed * Time.deltaTime), ForceMode.Acceleration);
        }

        public void SwitchMovementLogic()
        {
            if (_isPhisic)
            {
                Move = MoveTransform;
                _isPhisic = false;
            }
            else
            {
                Move = MovePhisic;
                _isPhisic = true;
            }
        }
    }
}