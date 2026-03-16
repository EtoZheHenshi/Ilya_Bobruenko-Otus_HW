using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Character Controller")]
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float gravity;
        [SerializeField] private float speed;
        [SerializeField] private float sprintSpeed;
        
        [Header("Camera")]
        [SerializeField] private Transform playerCameraTarget;
        [SerializeField] private float downAngleLimit;
        [SerializeField] private float upAngleLimit;

        public Vector2 CameraRotation { get; set; }
        
        private const float ConstYVelocity = 2.0f;

        private float _cinemachineTargetYaw;
        private float _cinemachineTargetPitch;

        private void Update()
        {
            CameraMovement();
        }

        private void CameraMovement()
        {
            if (CameraRotation != Vector2.zero)
            {
                _cinemachineTargetYaw += CameraRotation.x;
                _cinemachineTargetPitch += CameraRotation.y;
            }
            
            _cinemachineTargetYaw = ClamAngel(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
            _cinemachineTargetPitch = ClamAngel(_cinemachineTargetPitch, downAngleLimit, upAngleLimit);
            
            playerCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch, _cinemachineTargetYaw, 0f);
        }

        private float ClamAngel(float angel, float minValue, float maxValue)
        {
            if (angel > 360f) angel -= 360f;
            if (angel < -360f) angel += 360f;
            
            return Mathf.Clamp(angel, minValue, maxValue);
        }
    }
}