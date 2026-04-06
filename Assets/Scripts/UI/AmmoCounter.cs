using System;
using TMPro;
using UnityEngine;
using Weapons;

namespace UI
{
    public class AmmoCounter : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;
        [SerializeField] private TMP_Text ammoText;

        private void Update()
        {
            ammoText.text = weapon.Ammo.ToString();
        }
    }
}