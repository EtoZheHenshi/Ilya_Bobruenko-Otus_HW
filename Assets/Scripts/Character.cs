using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters
{
    public class Character : MonoBehaviour
    {
        public Renderer character;
        
        void Start()
        {
            ChangeColorToCharacter();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangeColorToCharacter();
            }
        }
        
        private void ChangeColorToCharacter()
        {
            int choiceSide = Random.Range(0, 2);
            
            character.material.color = choiceSide switch
            {
                0 => Color.softRed,
                1 => Color.cornflowerBlue,
                _ => LogError()
            };

            Color LogError()
            {
                Debug.Log("Что-то пошло не так с изменением цвета у персонажа");
                return character.material.color;
            }
        }
    }
}
