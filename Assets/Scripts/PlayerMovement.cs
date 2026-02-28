using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody rb;

        [Header("Camera")]
        [SerializeField] private Transform cameraTarget;
        [SerializeField] private float cameraTopClamp;
        [SerializeField] private float cameraDownClamp;
        [SerializeField] private float cameraLeftClamp;
        [SerializeField] private float cameraRightClamp;

        public Vector3 MoveDirection { get; set; }
        public Vector2 CameraRotationDirection { get; set; }
        
        private bool _isPhisic;
        
        private float _targetYaw;
        private float _targetPitch;

        private float _rotationVelocity;
        private float _rotationSmoothTime = 0.12f;
        private float _targetRotation;

        private Action<Vector3, float> Move { get; set; }
        private Action<float> Rotate { get; set; }

        private GameObject _mainCamera;

        private void Awake()
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        private void Start()
        {
            Move = MoveTransform;
            Rotate = RotateTransform;
        }

        private void Update()
        {
            if (!_isPhisic)
            {
                CameraRotation();
                MoveAndRotate();
            }
        }

        private void FixedUpdate()
        {
            if (_isPhisic)
            {
                CameraRotation();
                MoveAndRotate();
            }
        }
        
        public void SwitchMovementLogic()
        {
            if (_isPhisic)
            {
                Move = MoveTransform;
                Rotate = RotateTransform;
                _isPhisic = false;
            }
            else
            {
                Move = MovePhisic;
                Rotate = RotatePhisic;
                _isPhisic = true;
            }
        }

        private void MoveAndRotate()
        {
            float targetSpeed = speed;

            if (MoveDirection == Vector3.zero)
            {
                targetSpeed = 0.0f;
            }
            
            if (MoveDirection != Vector3.zero)
            {
                _targetRotation = Mathf.Atan2(MoveDirection.x, MoveDirection.z) * Mathf.Rad2Deg +
                                  _mainCamera.transform.eulerAngles.y;
                float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, _rotationSmoothTime);
                Rotate(rotation);
            }
            
            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
            Move(targetDirection.normalized, targetSpeed);
        }

        private void MoveTransform(Vector3 direction, float speed)
        {
            transform.Translate(direction.normalized * (speed * Time.deltaTime), Space.World);
        }
        
        private void MovePhisic(Vector3 direction, float speed)
        {
            rb.linearVelocity = direction * speed;
        }

        private void RotateTransform(float rotation)
        {
            transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        }

        private void RotatePhisic(float rotation)
        {
            rb.MoveRotation(Quaternion.Euler(0f, rotation, 0f));
        }

        private void CameraRotation()
        {
            if (CameraRotationDirection != Vector2.zero)
            {
                _targetYaw += CameraRotationDirection.x;
                _targetPitch += CameraRotationDirection.y;
            }
            
            _targetYaw = ClampAngle(_targetYaw, cameraLeftClamp, cameraRightClamp);
            _targetPitch = ClampAngle(_targetPitch, cameraDownClamp, cameraTopClamp);
            
            cameraTarget.rotation = Quaternion.Euler(_targetPitch, _targetYaw, 0.0f);
        }
        
        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
    }
}