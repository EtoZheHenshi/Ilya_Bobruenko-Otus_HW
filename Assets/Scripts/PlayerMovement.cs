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

        public Vector3 InputMoveDirection { get; set; }
        public Vector2 InputCameraRotationDirection { get; set; }
        
        private bool _isPhisic = false;
        
        private float _targetYaw;
        private float _targetPitch;

        private float _rotationVelocity;
        private float _rotationSmoothTime = 0.12f;
        private float _targetRotation;

        private Vector3 _characterMoveDirection;
        private float _characterMoveSpeed;
        private float _characterRotation;

        private GameObject _mainCamera;

        private void Awake()
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        private void Update()
        {
            CameraRotation();
            MoveAndRotate();
            if (!_isPhisic)
            {
                CalculateRotation(Time.deltaTime);
                MoveTransform();
                RotateTransform();
            }
        }

        private void FixedUpdate()
        {
            if (_isPhisic)
            {
                CalculateRotation(Time.fixedDeltaTime);
                RotatePhisic();
                MovePhisic();
            }
        }
        
        public void SwitchMovementLogic()
        {
            _isPhisic = !_isPhisic;

            if (_isPhisic)
            {
                rb.isKinematic = false;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            else
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
                rb.interpolation = RigidbodyInterpolation.None;
            }
        }

        private void MoveAndRotate()
        {
            _characterMoveSpeed = speed;

            if (InputMoveDirection == Vector3.zero)
            {
                _characterMoveSpeed = 0.0f;
            }
            
            if (InputMoveDirection != Vector3.zero)
            {
                _targetRotation = Mathf.Atan2(InputMoveDirection.x, InputMoveDirection.z) * Mathf.Rad2Deg +
                                  _mainCamera.transform.eulerAngles.y;
            }
            
            _characterMoveDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
        }
        
        private void CalculateRotation(float deltaTime)
        {
            float currentRotation = _isPhisic ? rb.rotation.eulerAngles.y : transform.eulerAngles.y;
            _characterRotation = Mathf.SmoothDampAngle(currentRotation, _targetRotation, ref _rotationVelocity, _rotationSmoothTime, Mathf.Infinity, deltaTime);
        }

        private void MoveTransform()
        {
            transform.Translate(_characterMoveDirection * (_characterMoveSpeed * Time.deltaTime), Space.World);
        }
        
        private void MovePhisic()
        {
            rb.linearVelocity = _characterMoveDirection * _characterMoveSpeed;
        }

        private void RotateTransform()
        {
            transform.rotation = Quaternion.Euler(0f, _characterRotation, 0f);
        }

        private void RotatePhisic()
        {
            rb.MoveRotation(Quaternion.Euler(0f, _characterRotation, 0f));
        }

        private void CameraRotation()
        {
            if (InputCameraRotationDirection != Vector2.zero)
            {
                _targetYaw += InputCameraRotationDirection.x;
                _targetPitch += InputCameraRotationDirection.y;
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