using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public int hp;
        public int damage;
        
        private bool _isDead;

        private void Start()
        {
            ShowHP();
            CheckDeathStatus();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetDamage();
            }
        }

        private void GetDamage()
        {
            if (!_isDead)
            {
                hp -= damage;

                if (hp < 0)
                {
                    hp = 0;
                }

                ShowHP();
                CheckDeathStatus();
            }
            else
            {
                Debug.Log("Player is dead");
            }
        }

        private void CheckDeathStatus()
        {
            if (hp == 0)
            {
                _isDead = true;
                Debug.Log("The player died");
            }
        }

        private void ShowHP()
        {
            Debug.Log("HP: " + hp);
        }
    }
}
