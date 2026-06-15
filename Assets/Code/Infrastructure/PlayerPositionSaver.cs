using System;
using Code.Gameplay.Character;
using UnityEngine;

namespace Code.Infrastructure
{
    public static class PlayerPositionSaver
    {
        public static Action SetCameraAction;
        
        private static GameObject _character;

        public static void SavePosition()
        {
            if (_character == null) return;
            
            PlayerPrefs.SetFloat("PositionX", _character.transform.position.x);
            PlayerPrefs.SetFloat("PositionY", _character.transform.position.y);
            PlayerPrefs.SetFloat("PositionZ", _character.transform.position.z);
            PlayerPrefs.SetInt("SaveComplete", 1);
            
            Debug.Log("Saved Position");
        }

        public static void LoadPosition()
        {
            if (_character == null) return;
            
            if (PlayerPrefs.HasKey("SaveComplete") && PlayerPrefs.GetInt("SaveComplete") == 1)
            {
                float x = PlayerPrefs.GetFloat("PositionX");
                float y = PlayerPrefs.GetFloat("PositionY");
                float z = PlayerPrefs.GetFloat("PositionZ");
                
                _character.transform.position = new Vector3(x, y, z);
                SetCameraAction?.Invoke();
                
                Debug.Log("Load Position");
            }
        }

        public static void SetCharacter(GameObject character)
        {
            _character = character;
        }
    }
}