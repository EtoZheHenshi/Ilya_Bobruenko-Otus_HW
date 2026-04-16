using System;
using Player;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Controls
{
    public sealed class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private WeaponController weaponController;
        [SerializeField] private UIController UIController;
        private GameInputSystem _inputSystem;

        private void Awake()
        {
            _inputSystem = new GameInputSystem();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnEnable()
        {
            _inputSystem.Player.Enable();
            
            _inputSystem.Player.Move.performed += Move;
            _inputSystem.Player.Move.canceled += Move;
            
            _inputSystem.Player.Sprint.started += Sprint;
            _inputSystem.Player.Sprint.canceled += Sprint;
            
            _inputSystem.Player.Attack.started += Attack;
            _inputSystem.Player.Attack.canceled += Attack;
            
            _inputSystem.Player.Look.performed += Look;
            _inputSystem.Player.Look.canceled += Look;

            _inputSystem.Player.Aim.started += Aim;
            _inputSystem.Player.Aim.canceled += Aim;

            _inputSystem.Player.Reload.started += Reload;
            _inputSystem.Player.Reload.canceled += Reload;

            _inputSystem.Player.WeaponSelect.performed += WeaponSelect;

            _inputSystem.Player.WeaponScroll.performed += WeaponScroll;

            _inputSystem.Player.Pause.started += Pause;
            
            _inputSystem.UI.Pause.started += Pause;
        }

        private void OnDisable()
        {
            _inputSystem.Player.Disable();
            _inputSystem.UI.Disable();
            
            _inputSystem.Player.Move.performed -= Move;
            _inputSystem.Player.Move.canceled -= Move;
            
            _inputSystem.Player.Sprint.started -= Sprint;
            _inputSystem.Player.Sprint.canceled -= Sprint;
            
            _inputSystem.Player.Attack.started -= Attack;
            _inputSystem.Player.Attack.canceled -= Attack;
            
            _inputSystem.Player.Look.performed -= Look;
            _inputSystem.Player.Look.canceled -= Look;
            
            _inputSystem.Player.Aim.started -= Aim;
            _inputSystem.Player.Aim.canceled -= Aim;

            _inputSystem.Player.Reload.started -= Reload;
            _inputSystem.Player.Reload.canceled -= Reload;
            
            _inputSystem.Player.WeaponSelect.performed -= WeaponSelect;
            
            _inputSystem.Player.WeaponScroll.performed -= WeaponScroll;
            
            _inputSystem.Player.Pause.started -= Pause;
            
            _inputSystem.UI.Pause.started -= Pause;
        }

        private void Update()
        {
            if (_inputSystem.Player.enabled && UIController.IsPause)
            {
                _inputSystem.Player.Disable();
                _inputSystem.UI.Enable();
            }
            
            if (_inputSystem.UI.enabled && !UIController.IsPause)
            {
                _inputSystem.UI.Disable();
                _inputSystem.Player.Enable();
            }
        }

        private void Move(InputAction.CallbackContext ctx)
        {
            Vector3 moveDirection = new Vector3(ctx.ReadValue<Vector2>().x, 0f, ctx.ReadValue<Vector2>().y);
            playerController.InputMovementDirection = moveDirection.normalized;
        }

        private void Sprint(InputAction.CallbackContext ctx)
        {
            playerController.IsSprinting = !playerController.IsSprinting;
        }

        private void Attack(InputAction.CallbackContext ctx)
        {
            weaponController.Attack();
        }
        
        private void Look(InputAction.CallbackContext ctx)
        {
            playerController.InputCameraRotation = ctx.ReadValue<Vector2>();
        }
        
        private void Aim(InputAction.CallbackContext ctx)
        {
            weaponController.Aim();
        }
        
        private void Reload(InputAction.CallbackContext ctx)
        {
            weaponController.Reload();
        }
        
        private void WeaponSelect(InputAction.CallbackContext ctx)
        {
            if (int.TryParse(ctx.control.name, out int index))
            {
                weaponController.SelectWeapon(index - 1);
            }
        }
        
        private void WeaponScroll(InputAction.CallbackContext ctx)
        {
            weaponController.ScrollWeapon(ctx.ReadValue<Vector2>().y);
        }
        
        private void Pause(InputAction.CallbackContext obj)
        {
            UIController.PauseSwitch();
        }
    }
}
