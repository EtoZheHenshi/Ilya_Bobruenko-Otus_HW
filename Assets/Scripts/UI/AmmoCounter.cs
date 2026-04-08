using Player;
using TMPro;
using UnityEngine;
using Weapons;

namespace UI
{
    public class AmmoCounter : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private TMP_Text ammoText;

        private void Update()
        {
            ammoText.text = playerController.Weapon.Ammo.ToString();
        }
    }
}