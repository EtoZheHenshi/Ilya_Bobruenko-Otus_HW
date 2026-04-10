using UnityEngine;

namespace Weapons
{
    public sealed class WeaponSelector
    {
        private readonly Weapon[] _weapons;
        private int _currentWeaponID;
        private Weapon _currentWeapon;

        public Weapon CurrentWeapon => _currentWeapon;

        public WeaponSelector(Weapon[] weapons)
        {
            _weapons = weapons;
        }

        public void SelectWeapon(int index)
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.gameObject.SetActive(false);
                _currentWeapon.IsShooting = false;
                _currentWeapon.IsReloading = false;
            }
            
            int id = Mathf.Abs(index % _weapons.Length);
            _currentWeapon = _weapons[id];
            _currentWeapon.gameObject.SetActive(true);
        }
    }
}