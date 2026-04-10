using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    public sealed class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
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
        }

        private void OnDisable()
        {
            _inputSystem.Player.Disable();
            
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
            playerController.Attack();
        }
        
        private void Look(InputAction.CallbackContext ctx)
        {
            playerController.InputCameraRotation = ctx.ReadValue<Vector2>();
        }
        
        private void Aim(InputAction.CallbackContext obj)
        {
            playerController.Aim();
        }
        
        private void Reload(InputAction.CallbackContext obj)
        {
            playerController.Reload();
        }
    }
}
