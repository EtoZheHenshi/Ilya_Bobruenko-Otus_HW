using Player;
using TMPro;
using UnityEngine;
using Weapons;

namespace UI
{
    public sealed class HUD : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private WeaponController weaponController;
        [SerializeField] private TMP_Text ammoText;
        [SerializeField] private TMP_Text weaponNameText;
        [SerializeField] private TMP_Text hpText;

        private void Update()
        {
            hpText.text = playerController.Hp.ToString();
            ammoText.text = weaponController.Weapon.Ammo.ToString();
            weaponNameText.text = weaponController.Weapon.WeaponName;
        }
    }
}