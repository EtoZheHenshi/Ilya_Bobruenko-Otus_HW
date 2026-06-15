using UnityEngine;
using UnityEngine.InputSystem;

namespace Code
{
    public class ImpulseToRigidbody : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _force;
        private Camera _camera;
        
        void Start()
        {
            _camera = Camera.main;
        }
        
        public void OnClick()
        {
            Debug.Log("Click");
            if (Physics.Raycast(_camera.ScreenPointToRay(Mouse.current.position.value), out RaycastHit hit, 500f, _layerMask))
            {
                if (hit.collider.TryGetComponent(out Rigidbody rb))
                {
                    rb.AddForce(new Vector3(
                        Random.Range(0f, 1f),
                        Random.Range(0f, 1f),
                        Random.Range(0f, 1f)
                        ).normalized * _force,
                        ForceMode.Impulse);
                }
            }
        }
    }
}
