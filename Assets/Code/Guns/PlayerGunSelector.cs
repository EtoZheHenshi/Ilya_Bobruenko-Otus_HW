using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Guns
{
    [DisallowMultipleComponent]
    public class PlayerGunSelector : MonoBehaviour
    {
        [SerializeField] private GunType Gun;
        [SerializeField] private Transform GunParent;
        [SerializeField] private List<GunSO> Guns;

        [Space] 
        [Header("Runtime Filled")] 
        public GunSO ActiveGun;

        private void Start()
        {
            GunSO gun = Guns.Find(gun => gun.Type == Gun);

            if (gun == null)
            {
                Debug.LogError($"No GunSO found for GunType: {gun}");
                return;
            }

            ActiveGun = gun;
            gun.Spawn(GunParent, this);
        }
    }
}