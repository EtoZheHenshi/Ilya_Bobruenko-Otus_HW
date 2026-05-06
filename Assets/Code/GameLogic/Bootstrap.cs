using Code.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.GameLogic
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private string nextSceneName;
        
        public static bool IsInitialized { get; private set; }
        public static string NextSceneName;
        
        private InputManager _inputManager;
        private bool _allInitialized = true;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _inputManager = GetComponentInChildren<InputManager>();

            Initialize();

            if (_allInitialized)
            {
                if (NextSceneName == null) NextSceneName = nextSceneName;
                
                IsInitialized = true;
                SceneManager.LoadScene(NextSceneName);
            }
        }

        private void Initialize()
        {
            _allInitialized = _inputManager.Initialize();
        }
    }
}