using Player;
using TMPro;
using UnityEngine;
using Weapons;

namespace UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private TMP_Text ammoText;
        [SerializeField] private TMP_Text weaponNameText;

        private void Update()
        {
            ammoText.text = playerController.Weapon.Ammo.ToString();
            weaponNameText.text = playerController.Weapon.WeaponName;
        }
    }
}