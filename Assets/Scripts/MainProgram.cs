using UnityEngine;

namespace Scripts
{
    public class MainProgram : MonoBehaviour
    {
        private int _intVariable = 5;
        private float _floatVariable = -3.235243f;
        private bool _boolVariable = true;
        
        private void Start()
        {
            Debug.Log($"Переменная int = {_intVariable.ToString()}");
            Debug.Log($"Переменная float = {_floatVariable.ToString("0.##")}");
            Debug.Log($"Переменная bool = {_boolVariable.ToString()}");
        }
    }
}
