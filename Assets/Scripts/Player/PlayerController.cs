using Audio;
using UnityEngine;
using Weapons;

namespace Player
{
    public sealed class PlayerController : MonoBehaviour
    {
        [Header("Character Controller")]
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float gravity;
        [SerializeField] private float speed;
        [SerializeField] private float sprintSpeed;

        [Header("Camera")] 
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Transform playerCameraTarget;
        [SerializeField] private float downAngleLimit;
        [SerializeField] private float upAngleLimit;

        [Header("Animator")]
        [SerializeField] private Animator animator;
        
        [Header("Weapons")]
        [SerializeField] private Weapon[] weapons;

        [Header("Sounds")] 
        [SerializeField] private SoundData stepsSound;

        public Weapon Weapon => _weaponSelector.CurrentWeapon;
        public Vector2 InputCameraRotation { get; set; }
        public Vector3 InputMovementDirection { get; set; }
        public bool IsSprinting { get; set; }

        private WeaponSelector _weaponSelector;

        private bool _isAttacking;
        private bool _isReloading;
        private bool _isAiming;
        
        private const float ConstYVelocity = -2.0f;

        private float _playerCameraTargetYaw;
        private float _playerCameraTargetPitch;

        private float _playerSpeed;
        private Vector3 _playerMovementDirection;
        private float _playerRotationTarget;
        private float _smoothVelocity;
        private readonly float _smoothTime = 0.12f;

        private void Start()
        {
            _weaponSelector = new WeaponSelector(weapons);
            SelectWeapon(0);
        }

        private void Update()
        {
            CameraMovement();
            MoveAndRotate();
        }

        private void MoveAndRotate()
        {
            if (InputMovementDirection == Vector3.zero)
            {
                _playerSpeed = 0f;
            }
            else if (IsSprinting)
            {
                _playerSpeed = sprintSpeed;
            }
            else
            {
                _playerSpeed = speed;
            }
            
            if (InputMovementDirection != Vector3.zero)
            {
                _playerRotationTarget = Mathf.Atan2(InputMovementDirection.x, InputMovementDirection.z) * Mathf.Rad2Deg +
                                        mainCamera.transform.eulerAngles.y;
                float rotationY = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, _playerRotationTarget,
                    ref _smoothVelocity, _smoothTime);
                transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
                
                _playerMovementDirection = Quaternion.Euler(0f, _playerRotationTarget, 0f) * Vector3.forward;
            }
            
            characterController.Move(_playerMovementDirection * (_playerSpeed * Time.deltaTime) +
                                     new Vector3(0f, ConstYVelocity * Time.deltaTime, 0f));
            
            animator.SetFloat("Speed", _playerSpeed);
            animator.SetBool("IsSprinting", IsSprinting);
        }

        private void CameraMovement()
        {
            if (InputCameraRotation != Vector2.zero)
            {
                _playerCameraTargetYaw += InputCameraRotation.x;
                _playerCameraTargetPitch += InputCameraRotation.y;
            }
            
            _playerCameraTargetYaw = ClamAngel(_playerCameraTargetYaw, float.MinValue, float.MaxValue);
            _playerCameraTargetPitch = ClamAngel(_playerCameraTargetPitch, downAngleLimit, upAngleLimit);
            
            playerCameraTarget.rotation = Quaternion.Euler(_playerCameraTargetPitch, _playerCameraTargetYaw, 0f);
        }

        private float ClamAngel(float angel, float minValue, float maxValue)
        {
            if (angel > 360f) angel -= 360f;
            if (angel < -360f) angel += 360f;
            
            return Mathf.Clamp(angel, minValue, maxValue);
        }

        public void Attack()
        {
            if (!_isAiming && !_isAttacking) return;
            _isAttacking = !_isAttacking;
            animator.SetBool("IsAttacking", _isAttacking);
            Weapon.IsShooting = !Weapon.IsShooting;
        }

        public void Aim()
        {
            _isAiming = !_isAiming;
            animator.SetBool("IsAiming", _isAiming);
        }

        public void Reload()
        {
            if (!_isReloading)
            {
                _isReloading = true;
                animator.SetTrigger("ReloadTrigger");
                Weapon.Reload();
            }
        }

        public void OnReloadEnd()
        {
            _isReloading = false;
            Weapon.IsReloading = false;
        }

        public void SelectWeapon(int index)
        {
            if (Weapon == null || index != Weapon.WeaponID)
            {
                _weaponSelector.SelectWeapon(index);
                OnReloadEnd();
                animator.SetInteger("WeaponType", Weapon.WeaponID);
                animator.SetTrigger("ChangeWeaponTrigger");
            }
        }

        public void ScrollWeapon(float direction)
        {
            if (direction > 0)
            {
                SelectWeapon(Weapon.WeaponID + 1);
            }
            else if (direction < 0)
            {
                if (Weapon.WeaponID == 0)
                {
                    SelectWeapon(weapons.Length - 1);
                }
                else
                {
                    SelectWeapon(Weapon.WeaponID - 1);
                }
            }
        }

        public void OnStepSound()
        {
            AudioManager.Instance.PlaySound(stepsSound, transform.position);
        }
    }
}