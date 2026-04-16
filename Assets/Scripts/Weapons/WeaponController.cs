using UnityEngine;

namespace Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Weapon[] weapons;
        [SerializeField] private Animator animator;
        
        public Weapon Weapon => _weaponSelector.CurrentWeapon;
        
        private WeaponSelector _weaponSelector;
        
        private bool _isAttacking;
        private bool _isReloading;
        private bool _isAiming;
        
        private void Start()
        {
            _weaponSelector = new WeaponSelector(weapons);
            SelectWeapon(0);
        }
        
        public void Attack()
        {
            if (!_isAiming && !_isAttacking) return;
            _isAttacking = !_isAttacking;
            animator.SetBool("IsAttacking", _isAttacking);
            Weapon.IsShooting = !Weapon.IsShooting;
        }

        public void Aim()
        {
            _isAiming = !_isAiming;
            animator.SetBool("IsAiming", _isAiming);
        }

        public void Reload()
        {
            if (!_isReloading)
            {
                _isReloading = true;
                animator.SetTrigger("ReloadTrigger");
                Weapon.Reload();
            }
        }

        public void OnReloadEnd()
        {
            _isReloading = false;
            Weapon.IsReloading = false;
        }

        public void SelectWeapon(int index)
        {
            if (Weapon == null || index != Weapon.WeaponID)
            {
                _weaponSelector.SelectWeapon(index);
                OnReloadEnd();
                animator.SetInteger("WeaponType", Weapon.WeaponID);
                animator.SetTrigger("ChangeWeaponTrigger");
            }
        }

        public void ScrollWeapon(float direction)
        {
            if (direction > 0)
            {
                SelectWeapon(Weapon.WeaponID + 1);
            }
            else if (direction < 0)
            {
                if (Weapon.WeaponID == 0)
                {
                    SelectWeapon(weapons.Length - 1);
                }
                else
                {
                    SelectWeapon(Weapon.WeaponID - 1);
                }
            }
        }
    }
}