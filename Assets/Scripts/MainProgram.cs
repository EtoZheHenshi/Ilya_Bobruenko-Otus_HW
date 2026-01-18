using Unity.VisualScripting;
using UnityEngine;

public class MainProgram : MonoBehaviour
{
    int _intVariable = 5;
    float _floatVariable = -3.235243f;
    bool _boolVariable = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"Переменная int = {_intVariable.ToString()}");
        Debug.Log($"Переменная float = {_floatVariable.ToString("0.##")}");
        Debug.Log($"Переменная bool = {_boolVariable.ToString()}");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
