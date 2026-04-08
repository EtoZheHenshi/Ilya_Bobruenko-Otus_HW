using Unity.VisualScripting;

namespace Weapons.AssaultRifle
{
    public class AssaultRifle : Weapon
    {
        private const string WEAPON_NAME = "AssaultRifle";

        protected override void Start()
        {
            base.Start();
            weaponName = WEAPON_NAME;
        }
    }
}